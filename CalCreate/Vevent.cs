// <copyright file="Vevent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalCreate
{
    using System;

    /// <summary>
    /// Vevent of ical.
    /// </summary>
    public class Vevent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vevent"/> class.
        /// </summary>
        public Vevent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vevent"/> class.
        /// 生成事件.
        /// </summary>
        /// <param name="uid">唯一ID.</param>
        /// <param name="stStamp">时间戳.</param>
        /// <param name="dtStart">开始时间.</param>
        /// <param name="dtEnd">结束时间.</param>
        /// <param name="summary">概述.</param>
        /// <param name="location">地点.</param>
        /// <param name="desription">描述.</param>
        /// <param name="rRule">重复规则.</param>
        public Vevent(string uid, DateTime stStamp, DateTime dtStart, DateTime dtEnd, string summary, string location, string desription, string rRule)
        {
            this.UID = uid;
            this.DTSTAMP = stStamp;
            this.DTSTART = dtStart;
            this.DTEND = dtEnd;
            this.SUMMARY = summary;
            this.LOCATION = location;
            this.DESCRIPTION = desription;
            this.RRULE = rRule;
        }

        /// <summary>
        /// Gets or sets 唯一ID.
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// Gets or sets 时间戳.
        /// </summary>
        public DateTime DTSTAMP { get; set; }

        /// <summary>
        /// Gets or sets 开始时间.
        /// </summary>
        public DateTime DTSTART { get; set; }

        /// <summary>
        /// Gets or sets 结束时间.
        /// </summary>
        public DateTime DTEND { get; set; }

        /// <summary>
        /// Gets or sets 事件概述.
        /// </summary>
        public string SUMMARY { get; set; }

        /// <summary>
        /// Gets or sets 发生地点.
        /// </summary>
        public string LOCATION { get; set; }

        /// <summary>
        /// Gets or sets 事件描述.
        /// </summary>
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// Gets or sets 事件循环规则.
        /// </summary>
        public string RRULE { get; set; }
    }
}
