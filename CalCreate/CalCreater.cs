// <copyright file="CalCreater.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalCreate
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// use for create ical file.
    /// </summary>
    public class CalCreater
    {
        /// <summary>
        /// 制作一个ICAL文件.
        /// </summary>
        /// <param name="eventList">事件列表.</param>
        /// <param name="filePath">文件生成地址.</param>
        /// <param name="prodId">日历ID -//hacksw/handcal//NONSGML v1.0//EN.</param>
        public static void CalendarMake(List<Vevent> eventList, string filePath, string prodId)
        {
            StreamWriter sw = new (filePath, false);
            sw.WriteLine("BEGIN:VCALENDAR");
            sw.WriteLine("VERSION:2.0");
            sw.WriteLine("X-WR-CALNAME:课程表"); // 自定义日历名称
            sw.WriteLine($"PRODID:{prodId}");

            // sw.WriteLine("CALSCALE:GREGORIAN");
            sw.WriteLine("METHOD:PUBLISH");
            foreach (var item in eventList)
            {
                WriteVevent(sw, item);
            }

            sw.WriteLine("END:VCALENDAR");
            sw.Close();
        }

        private static void WriteVevent(StreamWriter sw, Vevent vevent)
        {
            // TODO utc 时区设置
            sw.WriteLine("BEGIN:VEVENT");
            sw.WriteLine($"UID:{vevent.UID}");
            sw.WriteLine($"SUMMARY:{vevent.SUMMARY}");
            sw.WriteLine($"LOCATION:{vevent.LOCATION}");
            sw.WriteLine($"DESCRIPTION:{vevent.DESCRIPTION}");

            sw.WriteLine($"DTSTAMP:{vevent.DTSTAMP:yyyyMMddTHHmmss}"); // 19970610T172345Z
            sw.WriteLine($"DTSTART:{vevent.DTSTART:yyyyMMddTHHmmss}");
            sw.WriteLine($"DTEND:{vevent.DTEND:yyyyMMddTHHmmss}");
            sw.WriteLine($"RRULE:{vevent.RRULE}");
            sw.WriteLine("END:VEVENT");
        }
    }
}
