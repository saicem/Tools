using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tools
{
    public class JwcSpider
    {
        private readonly HttpClient _client;

        public JwcSpider()
        {
            _client = new HttpClient(new HttpClientHandler() { UseCookies = true });
            _client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.18363");
        }

        public async Task<bool> SetInfo(string userName, string password)
        {
            User.name = userName;
            User.passwd = password;
            var html = await Spider.GetHomePage(_client);
            bool isVaildUser = Verify.IsValidUser(html);
            State.validUser = isVaildUser;
            return isVaildUser;
        }

        public async Task<string> GetHomePage()
        {
            if (State.validUser)
            {
                return await Spider.GetHomePage(_client);
            }
            else
            {
                throw new Exception("need a valid user");
            }
        }

        private class Spider
        {
            public static async Task<string> GetHomePage(HttpClient httpClient)
            {
                string userName1 = Md5(User.name);
                string password1 = Sha1(User.passwd + User.passwd);
                string webfinger = GenerateFakeFinger();
                string rnd = new Random().Next(10000, 99999).ToString();
                string type = "xs";
                string urlCode = $"{URI.GetCode}?webfinger={webfinger}";
                // 获得JSESSIONID
                var resp = await httpClient.GetAsync(urlCode);
                string code = await resp.Content.ReadAsStringAsync();
                HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"userName",User.name },
                    {"password",User.passwd },
                    {"userName1",userName1 },
                    {"password1",password1 },
                    {"webfinger",webfinger },
                    {"rnd",rnd },
                    {"type",type },
                    {"code",code }
                });
                // 获得一个 CERLOGIN
                resp = await httpClient.PostAsync(URI.Login, httpContent);
                var html = await resp.Content.ReadAsStringAsync();
                return html;
            }

            public static async Task<string> GetRooms(HttpClient httpClient)
            {
                if (!State.validUser)
                {
                    throw new Exception("wrong username or password");
                }
                // 先请求课程查询页面获得cookie
                var resp = await httpClient.GetAsync(URI.RoomPage);

                if (!resp.IsSuccessStatusCode)
                {
                    throw new Exception("can't get the page of course");
                }
                HttpContent httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"xnxq", "2020-2021-2"},
                    {"xm","%" }
                });
                resp = await httpClient.PostAsync(URI.Room, httpContent);
                return await resp.Content.ReadAsStringAsync();
            }
        }

        private class Verify
        {
            public static bool IsValidUser(string html)
            {
                return Regex.IsMatch(html, "武汉理工大学学分制教务管理信息系统");
            }
        }

        private class User
        {
            public static string name;
            public static string passwd;
        }
        private class State
        {
            public static bool validUser = false;
        }

        private class URI
        {
            public const string GetCode = "http://sso.jwc.whut.edu.cn/Certification/getCode.do";
            public const string Login = "http://sso.jwc.whut.edu.cn/Certification/login.do";
            // 以下为成绩查询页面的
            public const string Score = "http://202.114.50.130/Score/";// 学分主界面 需要 JSESSIONID CERLOGIN
            public const string Rank = "http://202.114.50.130/Score/xftjList.do";// 绩点及排名查询 包括学分要求及获得情况 学年和总平均绩点 班级和年级排名
            public const string CET = "http://202.114.50.130/Score/djksList.do";// 等级考试查询
            public const string Pth = "http://202.114.50.130/Score/pthkscjList.do";// 普通话测试成绩查询
            public const string Kwxf = "http://202.114.50.130/Score/xskwxfList.do";// 课外学分查询
            public const string Grade = "http://202.114.50.130/Score/lscjList.do";// 成绩查询 可行的 需要参数 pageNum numPerPage xh snkey

            //public const string UriGrade = "http://202.114.50.130/Score/yxcjList.do";
            public const string RoomPage = "http://202.114.50.130/DailyMgt";
            public const string Room = "http://202.114.50.130/DailyMgt/jsList.do";
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

        private static string GenerateFakeFinger()
        {
            var random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var finger = new string(Enumerable.Repeat(chars, 32).Select(s => s[random.Next(chars.Length)]).ToArray());
            return finger;
        }
    }
}
