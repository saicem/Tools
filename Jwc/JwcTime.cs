// <copyright file="JwcTime.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Use for get Jwc time.
    /// </summary>
    public class JwcTime
    {
        /// <summary>
        /// Gets 开学第一周周一的前一天.
        /// </summary>
        public static DateTime TermStart { get; private set; } = JwcConfig.TermStart;

        /// <summary>
        /// Gets 本周是学期第几周.
        /// </summary>
        public static int Week
        {
            // FIX 跨年时会出错
            get => ((DateTime.Now.DayOfYear - TermStart.DayOfYear) / 7) + 1;
        }

        /// <summary>
        /// 获取这一周的周一.
        /// </summary>
        /// <param name="jwcWeek">week start from 1.</param>
        /// <returns>date.</returns>
        public static DateTime GetMondayOfWeek(int jwcWeek)
        {
            return TermStart + new TimeSpan(7 * (jwcWeek - 1), 0, 0, 0);
        }

        /// <summary>
        /// 获取某节课的上课时间.
        /// </summary>
        /// <param name="week">那节课是第几周.</param>
        /// <param name="day">那节课是周几.</param>
        /// <param name="section">第几节课(1-13).</param>
        /// <returns>那节课的开始时间.</returns>
        public static DateTime GetCourseStartDate(int week, DayOfWeek day, int section)
        {
            return GetDate(week, day) + GetCourseStartTime(section);
        }

        /// <summary>
        /// 获取某节课的上课时间.
        /// </summary>
        /// <param name="day">开学第几天.</param>
        /// <param name="section">第几节课(1-13).</param>
        /// <returns>那节课的上课时间.</returns>
        public static DateTime GetCourseStartDate(int day, int section)
        {
            return GetDate(day) + GetCourseStartTime(section);
        }

        /// <summary>
        /// 获取某节课的下课时间.
        /// </summary>
        /// <param name="week">那节课是第几周.</param>
        /// <param name="day">那节课是周几.</param>
        /// <param name="section">第几节课(1-13).</param>
        /// <returns>那节课的下课时间.</returns>
        public static DateTime GetCourseEndDate(int week, DayOfWeek day, int section)
        {
            return GetDate(week, day) + GetCourseEndTime(section);
        }

        /// <summary>
        /// 获取某节课的下课时间.
        /// </summary>
        /// <param name="day">那节课是开学第几天.</param>
        /// <param name="section">第几节课(1-13).</param>
        /// <returns>那节课的下课时间.</returns>
        public static DateTime GetCourseEndDate(int day, int section)
        {
            return GetDate(day) + GetCourseEndTime(section);
        }

        /// <summary>
        /// 获取上课时间.
        /// </summary>
        private static TimeSpan GetCourseStartTime(int section)
        {
            var dic = new Dictionary<int, string>
            {
                { 1, "08:00:00" },
                { 3, "09:55:00" },
                { 6, "14:00:00" },
                { 9, "16:45:00" },
                { 11, "19:00:00" },
            };
            return TimeSpan.Parse(dic[section]);
        }

        private static TimeSpan GetCourseEndTime(int section)
        {
            var map = new Dictionary<int, string>
            {
                { 1, "08:45:00" },
                { 2, "09:35:00" },
                { 3, "10:40:00" },
                { 4, "11:30:00" },
                { 5, "12:20:00" },
                { 6, "14:45:00" },
                { 7, "15:35:00" },
                { 8, "16:25:00" },
                { 9, "17:30:00" },
                { 10, "18:20:00" },
                { 11, "19:45:00" },
                { 12, "20:35:00" },
                { 13, "21:25:00" },
            };
            return TimeSpan.Parse(map[section]);
        }

        /// <summary>
        /// 获取日期.
        /// </summary>
        /// <param name="week">开学第几周.</param>
        /// <param name="day">一周中的第几天.</param>
        /// <returns>对应日期.</returns>
        private static DateTime GetDate(int week, DayOfWeek day)
        {
            return TermStart + new TimeSpan((7 * (week - 1)) + (((int)day + 6) % 7), 0, 0, 0);
        }

        /// <summary>
        /// 获取日期.
        /// </summary>
        /// <param name="day">The day after this term, start from 1.</param>
        /// <returns>the datetime of the that day.</returns>
        private static DateTime GetDate(int day)
        {
            return TermStart + new TimeSpan((day + 6) % 7, 0, 0, 0);
        }
    }
}
