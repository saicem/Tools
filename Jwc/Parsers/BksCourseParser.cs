// <copyright file="BksCourseParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Jwc.Models;

    public class BksCourseParser
    {
        private readonly string dataSource;

        public BksCourseParser(string dataSource)
        {
            this.dataSource = dataSource;
        }

        // bool IsContentValid()
        // {
        //    return Regex.IsMatch(_dataSource, @"武汉理工大学学分制教务管理信息系统");
        // }
        public IEnumerable<Course> Parse()
        {
            var content = Regex.Replace(this.dataSource, @"[\r\t\n]", string.Empty);
            ParseTeacherDic(content, out Dictionary<string, string> courseTeacherDic, out Dictionary<string, string> courseCreditDic);
            var table = Regex.Matches(content, @"<tbody.+?table-class-even.>(.*?)</tbody>")[1].Groups[1].Value;
            var trMatch = Regex.Match(table, @"<tr>(.*?)</tr>");
            int section = 1; // 大节数
            while (trMatch.Success)
            {
                int weekDay = 1; // 星期几
                var tr = trMatch.Groups[1].Value;
                var tdMatch = Regex.Match(tr, @"<td style.*?>(.*?)</td>");
                while (tdMatch.Success)
                {
                    var td = tdMatch.Groups[1].Value;
                    var divMatch = Regex.Match(td, @"<div.*?>.*?<a.*?>(.*?)</a>.*?</div>");
                    while (divMatch.Success)
                    {
                        var div = divMatch.Groups[1].Value;

                        // 凸优化<p>@致远(原教1)-209</p><p>◇第07-08周,11-15周,17-18周(3-4节)</p>
                        // var info = Regex.Match(div, @"(.+?)<p>@(.*?)</p><p>◇第(\d+)-(\d+)周\((\d+)-(\d+)节\)</p>");
                        var info = Regex.Match(div, @"(.+?)\s*?<p>@(.*?)</p>.*?<p>◇第(.+?)\((\d+)-(\d+)节\)</p>");
                        var weekStr = info.Groups[3].Value;
                        var weekMatch = Regex.Match(weekStr, @"(\d+)-(\d+)周");
                        while (weekMatch.Success)
                        {
                            var course = new Course
                            {
                                CourseName = info.Groups[1].Value,
                                Room = info.Groups[2].Value,
                                WeekStart = int.Parse(weekMatch.Groups[1].Value),
                                WeekEnd = int.Parse(weekMatch.Groups[2].Value),
                                SectionStart = int.Parse(info.Groups[4].Value),
                                SectionEnd = int.Parse(info.Groups[5].Value),
                                DayOfWeek = (DayOfWeek)(weekDay % 7),
                                Teacher = string.Empty,
                            };
                            if (courseTeacherDic.ContainsKey(course.CourseName))
                            {
                                course.Teacher = courseTeacherDic[course.CourseName];
                            }

                            if (courseCreditDic.ContainsKey(course.CourseName))
                            {
                                course.Credit = courseCreditDic[course.CourseName];
                            }

                            yield return course;
                            weekMatch = weekMatch.NextMatch();
                        }

                        divMatch = divMatch.NextMatch();
                    }

                    tdMatch = tdMatch.NextMatch();
                    weekDay++;
                }

                trMatch = trMatch.NextMatch();
                section++;
            }
        }

        private static void ParseTeacherDic(string content, out Dictionary<string, string> teachers, out Dictionary<string, string> credits)
        {
            var teacherDic = new Dictionary<string, string>();
            var creditDic = new Dictionary<string, string>();
            var teacherTable = Regex.Match(content, @"本学期已选课程.*<tbody>(.*?)</tbody>").Groups[1].Value;
            var trMatches = Regex.Matches(teacherTable, @"<tr>(.*?)</tr>");
            foreach (Match match in trMatches)
            {
                var tr = match.Groups[1].Value;
                var tdMatches = Regex.Matches(tr, @"<td>(.*?)</td>");
                var course = tdMatches[0].Groups[1].Value;
                var teacher = tdMatches[4].Groups[1].Value;
                var credit = tdMatches[1].Groups[1].Value;
                teacherDic.Add(course, teacher);
                creditDic.Add(course, credit);
            }

            teachers = teacherDic;
            credits = creditDic;
        }
    }
}
