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
        public Exam(string name, string course, string time, string place)
        {
            this.Name = name;
            this.Course = course;
            this.Time = time;
            this.Place = place;
        }

        public string Name { get; set; }

        public string Course { get; set; }

        public string Time { get; set; }

        public string Place { get; set; }
    }
}