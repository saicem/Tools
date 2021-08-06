// <copyright file="JwcCore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Jwc.Models;
    using Jwc.Parsers;

    /// <summary>
    /// 教务处核心组件.
    /// </summary>
    public class JwcCore
    {
        private readonly Spider spider;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwcCore"/> class.
        /// 教务处核心组件.
        /// </summary>
        /// <param name="userName">用户名.</param>
        /// <param name="password">密码.</param>
        public JwcCore(string userName, string password) => this.spider = new Spider(userName, password);

        /// <summary>
        /// 验证用户是否是教务处用户（本科生） 是 则返回姓名.
        /// </summary>
        /// <returns>null 为验证失败 验证成功返回姓名.</returns>
        public async Task<string> VerifyAsync()
        {
            string mainHtml = await this.spider.GetMainAsync();
            var newHtml = Regex.Replace(mainHtml, "\\s", string.Empty);
            var div = Regex.Match(newHtml, "<div.+?main-per-name\">(.+?)</div>");
            if (div.Success)
            {
                var name = Regex.Match(div.Groups[1].Value, "<b>(.+?)</b>");
                return name.Groups[1].Value;
            }

            return null;
        }

        /// <summary>
        /// 获取课程列表.
        /// </summary>
        /// <returns>null: if can't.</returns>
        public async Task<List<Course>> GetCoursesAsync()
        {
            string mainHtml = await this.spider.GetMainAsync();
            if (!Regex.IsMatch(mainHtml, "个人信息"))
            {
                return null;
            }

            var courses = new BksCourseParser(mainHtml).Parse();

            return courses.ToList();
        }

        /// <summary>
        /// get notice string.
        /// </summary>
        /// <returns>notice | null if not find.</returns>
        public async Task<string> GetNoticesAsync()
        {
            string mainHtml = await this.spider.GetMainAsync();
            return NoticeParser.GetNoticeList(mainHtml);
        }
    }
}
