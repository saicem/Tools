using Jwc.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Jwc.Parsers
{
    public static class GradeParser
    {
        public static string GetSnkey(string text)
        {
            string x = Regex.Match(text, "\\?snkey=(.+?)\"").Groups[1].Value;
            return x;
        }

        /// <summary>
        /// 得到成绩的详细信息
        /// </summary>
        /// <param name="html">成绩页面的html</param>
        /// <returns>包含成绩信息的列表</returns>
        public static List<Grade> GetGradeList(string html)
        {
            List<Grade> gradeLs = new();
            html = RegexHtml.ClearWhiteSpace(html);
            var tbody = RegexHtml.GetTagContents(html, "tbody")[0];
            var trs = RegexHtml.GetTagContents(tbody, "tr", ".+?");
            foreach (var tr in trs)
            {
                var tds = RegexHtml.GetTagContentsEmpty(tr, "td");
                gradeLs.Add(new Grade(tds));
            }
            return gradeLs;
        }
    }
}
