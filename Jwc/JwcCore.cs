using Jwc.Models;
using Jwc.Parsers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jwc
{
    public class JwcCore
    {
        readonly Spider spider;
        public JwcCore(string userName, string password)
        {
            spider = new Spider(userName, password);
        }

        /// <summary>
        /// 验证用户是否是教务处用户（本科生）
        /// </summary>
        /// <returns>true: can false: may username or password is wrong</returns>
        public bool Verify()
        {
            string mainHtml = spider.GetMain();
            if (Regex.IsMatch(mainHtml, "个人信息"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <returns>null: if can't</returns>
        public List<Course> GetCourses()
        {
            string mainHtml = spider.GetMain();
            if (!Regex.IsMatch(mainHtml, "个人信息"))
            {
                return null;
            }
            var Courses = new BksCourseParser(mainHtml).Parse();

            return Courses.ToList();
        }

        /// <summary>
        /// get notice string
        /// </summary>
        /// <returns>notice | null if not find</returns>
        public string GetNotices()
        {
            string mainHtml = spider.GetMain();
            return NoticeParser.GetNoticeList(mainHtml);
        }

        // TODO 寝室电费查询
    }
}
