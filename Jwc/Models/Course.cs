// <copyright file="Course.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc.Models
{
    using System;

    /// <summary>
    /// the course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the room of the course.
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Gets or sets the start teaching week of the course.
        /// </summary>
        public int WeekStart { get; set; }

        /// <summary>
        /// Gets or sets the end teaching week of the course.
        /// </summary>
        public int WeekEnd { get; set; }

        /// <summary>
        /// Gets the weekspan of the startweek to endweek.
        /// </summary>
        public int WeekSpan
        {
            get { return this.WeekEnd - this.WeekStart + 1; }
        }

        /// <summary>
        /// Gets or sets the start small section.
        /// </summary>
        public int SectionStart { get; set; }

        /// <summary>
        /// Gets or sets the end small section.
        /// </summary>
        public int SectionEnd { get; set; }

        /// <summary>
        /// Gets the total small section of this course.
        /// </summary>
        public int ClassSpan
        {
            get { return this.SectionEnd - this.SectionStart + 1; }
        }

        /// <summary>
        /// Gets the order of big course (one big course include 2 or 3 small section).
        /// </summary>
        public int BigSectionOrder
        {
            get { return GetSection(this.SectionStart); }
        }

        /// <summary>
        /// Gets or sets the day of the week about this course.
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the teacher of this course.
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Gets or sets the credit of this course.
        /// </summary>
        public string Credit { get; set; }

        /// <summary>
        /// Gets or sets the status of evalute the teaching.
        /// </summary>
        public string Status { get; set; }// 是否评教

        /// <summary>
        /// get the big section from the small section.
        /// </summary>
        /// <param name="classStart">the first small section order.</param>
        /// <returns>the big section order.</returns>
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
