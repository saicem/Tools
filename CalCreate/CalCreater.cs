using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalCreate
{
    public class CalCreater
    {
        /// <summary>
        /// 制作一个ICAL文件
        /// </summary>
        /// <param name="eventList">事件列表</param>
        /// <param name="filePath">文件生成地址</param>
        /// <param name="PRODID">日历ID -//hacksw/handcal//NONSGML v1.0//EN</param>
        public static void CalendarMake(List<Vevent> eventList, string filePath, string PRODID)
        {
            StreamWriter sw = new(filePath, false);
            sw.WriteLine("BEGIN:VCALENDAR");
            sw.WriteLine("VERSION:2.0");
            sw.WriteLine("X-WR-CALNAME:课程表");//自定义日历名称
            sw.WriteLine($"PRODID:{PRODID}");//
            //sw.WriteLine("CALSCALE:GREGORIAN");
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

            sw.WriteLine($"DTSTAMP:{vevent.DTSTAMP:yyyyMMddTHHmmss}"); //19970610T172345Z
            sw.WriteLine($"DTSTART:{vevent.DTSTART:yyyyMMddTHHmmss}");
            sw.WriteLine($"DTEND:{vevent.DTEND:yyyyMMddTHHmmss}");
            sw.WriteLine($"RRULE:{vevent.RRULE}");
            sw.WriteLine("END:VEVENT");
        }
    }

    public static class DowStr
    {
        public static string Get(int index)
        {
            if (index < 0 || index >= 7)
            {
                throw new IndexOutOfRangeException("day of week should be 0 to 6");
            }
            return index switch
            {
                0 => "SU",
                1 => "MO",
                2 => "TU",
                3 => "WE",
                4 => "TH",
                5 => "FR",
                6 => "SA",
                _ => "Undefined",
            };
        }

        public static string Get(DayOfWeek dayOfWeek)
        {
            int index = (int)dayOfWeek;
            return index switch
            {
                0 => "SU",
                1 => "MO",
                2 => "TU",
                3 => "WE",
                4 => "TH",
                5 => "FR",
                6 => "SA",
                _ => "Undefined",
            };
        }
    }

    public class Vevent
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime DTSTAMP { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DTSTART { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DTEND { get; set; }
        /// <summary>
        /// 事件概述
        /// </summary>
        public string SUMMARY { get; set; }
        /// <summary>
        /// 发生地点
        /// </summary>
        public string LOCATION { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 事件循环规则
        /// </summary>
        public string RRULE { get; set; }

        public Vevent()
        {

        }

        /// <summary>
        /// 生成事件
        /// </summary>
        /// <param name="UID">唯一ID</param>
        /// <param name="DTSTAMP">时间戳</param>
        /// <param name="DTSTART">开始时间</param>
        /// <param name="DTEND">结束时间</param>
        /// <param name="SUMMARY">概述</param>
        /// <param name="LOCATION">地点</param>
        /// <param name="DESCRIPTION">描述</param>
        /// <param name="RRULE">重复规则</param>
        public Vevent(string UID, DateTime DTSTAMP, DateTime DTSTART, DateTime DTEND, string SUMMARY, string LOCATION, string DESCRIPTION, string RRULE)
        {
            this.UID = UID;
            this.DTSTAMP = DTSTAMP;
            this.DTSTART = DTSTART;
            this.DTEND = DTEND;
            this.SUMMARY = SUMMARY;
            this.LOCATION = LOCATION;
            this.DESCRIPTION = DESCRIPTION;
            this.RRULE = RRULE;
        }
    }
}
