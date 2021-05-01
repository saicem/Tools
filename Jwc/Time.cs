using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwc
{
    public class JwcTime
    {
        /// <summary>
        /// 开学第一周周一
        /// </summary>
        public static DateTime TermStart { get; private set; } = Config.TermStart;

        /// <summary>
        /// 本周是学期第几周
        /// </summary>
        public static int Week
        {
            get => (DateTime.Now.DayOfYear - TermStart.DayOfYear) / 7 + 1;
        }

        public static DateTime GetMondayOfWeek(int jwcWeek)
        {
            return TermStart + new TimeSpan(7 * (jwcWeek - 1), 0, 0, 0);
        }

        public static DateTime GetCourseStartDate(int week, DayOfWeek day, int section)
        {
            return GetDate(week, day) + GetCourseStartTime(section);
        }

        public static DateTime GetCourseEndDate(int week, DayOfWeek day, int section, int length)
        {
            return GetDate(week, day) + GetCourseEndTime(section, length);
        }

        /// <summary>
        /// 获取上课时间
        /// </summary>
        private static TimeSpan GetCourseStartTime(int section)
        {
            var dic = new Dictionary<int, string>
            {
                {1, "08:00:00" },
                {2, "09:55:00" },
                {3, "14:00:00" },
                {4, "16:45:00" },
                {5, "19:00:00" }
            };
            if (!dic.ContainsKey(section)) return new TimeSpan(0);
            return TimeSpan.Parse(dic[section]);
        }

        /// <summary>
        /// 获取下课时间
        /// </summary>
        private static TimeSpan GetCourseEndTime(int section, int length)
        {
            var map = new Dictionary<int, Dictionary<int, string>> {
                {2, new Dictionary<int, string>
                    {
                        {1, "09:35:00" },
                        {2, "11:30:00" },
                        {3, "15:35:00" },
                        {4, "18:20:00" },
                        {5, "20:35:00" }
                    }
                },
                {3, new Dictionary<int, string>
                    {
                        {1, "09:35:00" },
                        {2, "12:20:00" },
                        {3, "16:25:00" },
                        {4, "18:20:00" },
                        {5, "21:25:00" }
                    }
                },
            };
            try
            {
                return TimeSpan.Parse(map[length][section]);
            }
            catch
            {
                return new TimeSpan(0);
            }
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="week">开学第几周</param>
        /// <param name="day">一周中的第几天</param>
        /// <returns>对应日期</returns>
        private static DateTime GetDate(int week, DayOfWeek day)
        {
            return TermStart + new TimeSpan(7 * (week - 1) + ((int)day + 6) % 7, 0, 0, 0);
        }
    }
}
