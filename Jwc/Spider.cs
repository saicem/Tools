using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Jwc
{
    class Spider
    {
        private readonly HttpClient client;
        private readonly string userName;
        private readonly string password;
        private const string UriCode = "http://sso.jwc.whut.edu.cn/Certification/getCode.do";
        private const string UriLogin = "http://sso.jwc.whut.edu.cn/Certification/login.do";
        // 以下为成绩查询页面的
        private const string UriScore = "http://202.114.50.130/Score/";// 学分主界面 需要 JSESSIONID CERLOGIN
        //private const string UriRank = "http://202.114.50.130/Score/xftjList.do";// 绩点及排名查询 包括学分要求及获得情况 学年和总平均绩点 班级和年级排名
        //private const string UriCET = "http://202.114.50.130/Score/djksList.do";// 等级考试查询
        //private const string UriPth = "http://202.114.50.130/Score/pthkscjList.do";// 普通话测试成绩查询
        //private const string UriKwxf = "http://202.114.50.130/Score/xskwxfList.do";// 课外学分查询
        private const string UriGrade = "http://202.114.50.130/Score/lscjList.do";// 成绩查询 可行的 需要参数 pageNum numPerPage xh snkey

        //private const string UriGrade = "http://202.114.50.130/Score/yxcjList.do";
        private const string UriRoomPage = "http://202.114.50.130/DailyMgt";
        private const string UriRoom = "http://202.114.50.130/DailyMgt/jsList.do";
        // 成绩查询 只能查询20条 参数未知

        public Spider(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            client = new HttpClient(new HttpClientHandler() { UseCookies = true });
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.18363");
        }

        /// <summary>
        /// 得到成绩页面的html
        /// </summary>
        /// <param name="snkey">snkey可以在score页面得到</param>
        /// <returns>成绩页面的html</returns>
        public string GetGrade(string snkey)
        {
            string url = $"{UriGrade}?pageNum=1&numPerPage=200&xh={userName}&snkey={snkey}";
            return client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 获取教务处主页的html 顺便获取 cookies 包括 JSESSIONID CERLOGIN
        /// </summary>
        /// <returns>教务处主页的html</returns>
        public string GetMain()
        {
            string userName1 = Md5(userName);
            string password1 = Sha1(userName + password);
            string webfinger = GenerateFakeFinger();
            string rnd = new Random().Next(10000, 99999).ToString();
            string type = "xs";
            string urlCode = $"{UriCode}?webfinger={webfinger}";
            string code = client.GetAsync(urlCode).Result.Content.ReadAsStringAsync().Result; // 获得 JSESSIONID
            HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"userName",userName},
                {"password",password },
                {"userName1",userName1 },
                {"password1",password1 },
                {"webfinger",webfinger },
                {"rnd",rnd },
                {"type",type },
                {"code",code }
            });
            var html = client.PostAsync(UriLogin, httpContent).Result.Content.ReadAsStringAsync().Result; // 获得 CERLOGIN
            return html;
        }

        /// <summary>
        /// 用于得到snkey
        /// </summary>
        /// <returns>score页面的html</returns>
        public string GetScorePage()
        {
            return client.GetAsync(UriScore).Result.Content.ReadAsStringAsync().Result;
        }

        public string GetRooms()
        {
            // 先请求课程查询页面获得cookie
            bool isSuccess = client.GetAsync(UriRoomPage).Result.IsSuccessStatusCode;
            if (!isSuccess)
            {
                throw new Exception("can't get the page of course query");
            }
            HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"xnxq", "2020-2021-2"},
                {"xm","%25" } // %25转义
            });
            var html = client.PostAsync(UriRoom, httpContent).Result.Content.ReadAsStringAsync().Result;
            return html;
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
