using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jwc.Parsers
{
    public static class NoticeParser
    {
        /// <summary>
        /// 从单条考试消息中提取实体类
        /// </summary>
        /// <param name="notice">考试消息</param>
        /// <returns>考试消息的实体类</returns>
        //private static Exam GetExamList(string notice)
        //{
        //    var match = Regex.Match(notice, "\\s(.+?)&nbsp;&nbsp;(.+?)&nbsp;&nbsp;考试临近请提前做好准备,考试时间:(.+?)&nbsp;&nbsp;,考试地点:(.+?)(?:\n)");
        //    return new Exam(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
        //}

        /// <summary>
        /// 得到消息列表，一般为考试信息。
        /// </summary>
        /// <param name="html">教务处主页</param>
        /// <returns>包含考试信息的字符串 | null: 没找到</returns>
        public static string GetNoticeList(string html)
        {
            var ul = Regex.Match(html, "<ul class=\"main-notice-list\">(.+?)</ul>", RegexOptions.Singleline);
            var li = ul.Groups[1].Value;
            if (li.Length != 0)
            {
                var notices = Regex.Matches(li, "<a href=\"#\" class=\"clearfix\">(.+?)</a>", RegexOptions.Singleline);
                List<string> noticeLs = (from Match notice in notices select notice.Groups[1].Value).ToList();
                return string.Join("\n", noticeLs);
            }
            return null;
        }

    }
}
