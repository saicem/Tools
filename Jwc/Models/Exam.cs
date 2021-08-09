// <copyright file="Exam.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc.Models
{
    /// <summary>
    /// 教务处消息提醒中的考试消息.
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exam"/> class.
        /// </summary>
        /// <param name="name">the user name.</param>
        /// <param name="course">the course name of exam.</param>
        /// <param name="time">the time when start exam.</param>
        /// <param name="place">the place of exam.</param>
        public Exam(string name, string course, string time, string place)
        {
            this.Name = name;
            this.Course = course;
            this.Time = time;
            this.Place = place;
        }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the course name of exam.
        /// </summary>
        public string Course { get; set; }

        /// <summary>
        /// Gets or sets the time when start exam.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the place of exam.
        /// </summary>
        public string Place { get; set; }
    }
}