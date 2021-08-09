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

    /// <summary>
    /// 教务处核心组件.
    /// </summary>
    public static class JwcCore
    {
        /// <summary>
        /// get is the user is valid.
        /// </summary>
        /// <param name="user">jwc user.</param>
        /// <returns>A <see cref="Task{TResult}"/> the name of the user. return is null if the username and the password are wrong.</returns>
        public static async Task<string> GetValidAsync(this JwcUser user)
        {
            string mainHtml = await user.FetchMainAsync();
            var newHtml = Regex.Replace(mainHtml, "\\s", string.Empty);
            var div = Regex.Match(newHtml, "<div.+?main-per-name\">(.+?)</div>");
            if (div.Success)
            {
                var name = Regex.Match(div.Groups[1].Value, "<b>(.+?)</b>");
                return name.Groups[1].Value;
            }

            if (Regex.IsMatch(newHtml, "如未收到验证码或电子邮件"))
            {
                return "请按照教务处要求更改密码后,再进行尝试。";
            }

            return null;
        }

        /// <summary>
        /// null if not get.
        /// </summary>
        /// <param name="user">jwc user.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public static async Task<List<Course>> GetCoursesAsync(this JwcUser user)
        {
            string mainHtml = await user.FetchMainAsync();
            if (!Regex.IsMatch(mainHtml, "个人信息"))
            {
                return null;
            }

            var courses = JwcParser.ParseBksCourse(mainHtml);

            return courses.ToList();
        }

        /// <summary>
        /// null if not get.
        /// </summary>
        /// <param name="user">jwc user.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public static async Task<string> GetNoticesAsync(this JwcUser user)
        {
            string mainHtml = await user.FetchMainAsync();
            return JwcParser.ParseNoticeList(mainHtml);
        }
    }
}
