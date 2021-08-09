// <copyright file="JwcSpider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Use for scrape the infos.
    /// </summary>
    public static class JwcSpider
    {
        private const string UriCode = "http://sso.jwc.whut.edu.cn/Certification/getCode.do";
        private const string UriLogin = "http://sso.jwc.whut.edu.cn/Certification/login.do";

        // 以下为成绩查询页面的
        private const string UriScore = "http://202.114.50.130/Score/"; // 学分主界面 需要 JSESSIONID CERLOGIN

        // private const string UriRank = "http://202.114.50.130/Score/xftjList.do";// 绩点及排名查询 包括学分要求及获得情况 学年和总平均绩点 班级和年级排名
        // private const string UriCET = "http://202.114.50.130/Score/djksList.do";// 等级考试查询
        // private const string UriPth = "http://202.114.50.130/Score/pthkscjList.do";// 普通话测试成绩查询
        // private const string UriKwxf = "http://202.114.50.130/Score/xskwxfList.do";// 课外学分查询
        private const string UriGrade = "http://202.114.50.130/Score/lscjList.do"; // 成绩查询 可行的 需要参数 pageNum numPerPage xh snkey

        // 成绩查询 只能查询20条 参数未知
        // private const string UriGrade = "http://202.114.50.130/Score/yxcjList.do";
        private const string UriRoomPage = "http://202.114.50.130/DailyMgt";
        private const string UriRoom = "http://202.114.50.130/DailyMgt/jsList.do";

        /// <summary>
        /// 得到成绩页面的html.
        /// </summary>
        /// <param name="user">jwc user.</param>
        /// <param name="snkey">snkey可以在score页面得到.</param>
        /// <returns>成绩页面的html.</returns>
        public static async Task<string> FetchGradeAsync(this JwcUser user, string snkey)
        {
            string url = $"{UriGrade}?pageNum=1&numPerPage=200&xh={user.UserName}&snkey={snkey}";
            var res = await user.Client.GetAsync(url);
            return await res.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// get the main page of jwc, also get cookies which include JSESSIONID CERLOGIN.
        /// </summary>
        /// <param name="user">Jwc user.</param>
        /// <returns>the main page html of jwc.</returns>
        public static async Task<string> FetchMainAsync(this JwcUser user)
        {
            string userName1 = Md5(user.UserName);
            string password1 = Sha1(user.UserName + user.Password);
            string webfinger = GenerateFakeFinger();
            string rnd = new Random().Next(10000, 99999).ToString();
            string type = "xs";
            string code = await FetchCodeAsync(user, webfinger);
            HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "code", code },
                { "webfinger", webfinger },
                { "userName", user.UserName },
                { "password", user.Password },
                { "userName1", userName1 },
                { "password1", password1 },
                { "rnd", rnd },
                { "type", type },
            });
            var html = await (await user.Client.PostAsync(UriLogin, httpContent)).Content.ReadAsStringAsync();

            // 获得 CERLOGIN
            return html;
        }

        /// <summary>
        /// 用于得到snkey.
        /// </summary>
        /// <param name="user">Jwc user.</param>
        /// <returns>score页面的html.</returns>
        public static async Task<string> GetScorePageAsync(this JwcUser user)
        {
            var res = await user.Client.GetAsync(UriScore);
            return await res.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Get the rooms of courses which will go to.
        /// </summary>
        /// <param name="user">Jwc user.</param>
        /// <returns>roooms.</returns>
        public static async Task<string> FetchRoomsAsync(this JwcUser user)
        {
            // 先请求课程查询页面获得cookie
            // 获得 JSESSIONID
            var resRoomPage = await user.Client.GetAsync(UriRoomPage);
            bool isSuccess = resRoomPage.IsSuccessStatusCode;
            if (!isSuccess)
            {
                throw new Exception("can't get the page of course query");
            }

            HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "xnxq", "2020-2021-2" },
                { "xm", "%25" },
            });
            var res = await user.Client.PostAsync(UriRoom, httpContent);
            var html = await res.Content.ReadAsStringAsync();
            return html;
        }

        private static async Task<string> FetchCodeAsync(this JwcUser user, string webfinger)
        {
            string urlCode = $"{UriCode}?webfinger={webfinger}";
            return await (await user.Client.GetAsync(urlCode)).Content.ReadAsStringAsync();
        }

        private static string GenerateFakeFinger()
        {
            var random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var finger = new string(Enumerable.Repeat(chars, 32).Select(s => s[random.Next(chars.Length)]).ToArray());
            return finger;
        }

        private static string Md5(string oldstring)
        {
            byte[] byteOld = Encoding.UTF8.GetBytes(oldstring);
            byte[] byteNew = MD5.Create().ComputeHash(byteOld);
            StringBuilder sb = new();
            foreach (var b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        private static string Sha1(string oldstring)
        {
            byte[] byteOld = Encoding.UTF8.GetBytes(oldstring);
            byte[] byteNew = SHA1.Create().ComputeHash(byteOld);
            StringBuilder sb = new();
            foreach (var b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
