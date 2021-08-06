// <copyright file="Course.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc.Models
{
    using System;

    public class Course
    {
        public string CourseName { get; set; }

        public string Room { get; set; }

        public int WeekStart { get; set; }

        public int WeekEnd { get; set; }

        public int WeekSpan
        {
            get { return this.WeekEnd - this.WeekStart + 1; }
        }

        public int SectionStart { get; set; }

        public int SectionEnd { get; set; }

        /// <summary>
        /// Gets 总共几节小课.
        /// </summary>
        public int ClassSpan
        {
            get { return this.SectionEnd - this.SectionStart + 1; }
        }

        /// <summary>
        /// Gets 大课时间.
        /// </summary>
        public int Section
        {
            get { return GetSection(this.SectionStart); }
        }

        public DayOfWeek DayOfWeek { get; set; }

        public string Teacher { get; set; }

        public string Credit { get; set; }

        public string Status { get; set; }// 是否评教

        public static int GetSection(int classStart)
        {
            return classStart switch
            {
                1 => 1,
                3 => 2,
                6 => 3,
                9 => 4,
                11 => 5,
                _ => -1,
            };
        }
    }
}
