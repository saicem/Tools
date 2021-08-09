// <copyright file="RegexHtml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// use regular expression to get infomations.
    /// </summary>
    internal class RegexHtml
    {
        /// <summary>
        /// 匹配目标并验证.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContentsCheck(string html, string tag)
        {
            MatchCollection matches = Regex.Matches(html, $@"<{tag}>(.+?)</{tag}>");
            if (matches.Count == 0)
            {
                throw new Exception("Can't find any tag from the html gived");
            }

            return (from Match item in matches select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 匹配目标并验证.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <param name="extra">标签额外信息.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContentsCheck(string html, string tag, string extra)
        {
            var contents = Regex.Matches(html, $@"<{tag}{extra}>(.+?)</{tag}>");
            if (contents.Count == 0)
            {
                throw new Exception("Can't find any tag from the html gived");
            }

            return (from Match item in contents select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 匹配目标.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContents(string html, string tag)
        {
            var contents = Regex.Matches(html, $@"<{tag}>(.+?)</{tag}>");
            return (from Match item in contents select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 匹配目标.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <param name="extra">标签额外信息.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContents(string html, string tag, string extra)
        {
            var contents = Regex.Matches(html, $@"<{tag}{extra}>(.+?)</{tag}>");
            return (from Match item in contents select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 匹配目标包括空标签.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContentsEmpty(string html, string tag)
        {
            var contents = Regex.Matches(html, $@"<{tag}>(.*?)</{tag}>");
            return (from Match item in contents select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 匹配目标包括空标签.
        /// </summary>
        /// <param name="html">匹配文本.</param>
        /// <param name="tag">标签名.</param>
        /// <param name="extra">标签额外信息.</param>
        /// <returns>得到文本.</returns>
        public static List<string> GetTagContentsEmpty(string html, string tag, string extra)
        {
            var contents = Regex.Matches(html, $@"<{tag}{extra}>(.*?)</{tag}>");
            return (from Match item in contents select item.Groups[1].Value).ToList();
        }

        /// <summary>
        /// 清除所有空白符.
        /// </summary>
        /// <param name="html">待清除的文本.</param>
        /// <returns>清楚后的文本.</returns>
        public static string ClearWhiteSpace(string html)
        {
            return Regex.Replace(html, @"\s", string.Empty);
        }
    }
}