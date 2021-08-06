// <copyright file="Grade.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// 学年学期
    /// 课程代码
    /// 课程名称
    /// 成绩课程性质
    /// 毕业课程性质
    /// 学分
    /// 总评成绩
    /// 成绩审核属性
    /// 最高成绩
    /// 首次成绩
    /// 考试状态
    /// 成绩类型
    /// 是否重修
    /// 学分绩点.
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Grade"/> class.
        /// 学年学期
        /// 课程代码
        /// 课程名称
        /// 成绩课程性质
        /// 毕业课程性质
        /// 学分
        /// 总评成绩
        /// 成绩审核属性
        /// 最高成绩
        /// 首次成绩
        /// 考试状态
        /// 成绩类型
        /// 是否重修
        /// 学分绩点.
        /// </summary>
        /// <param name="yearSemester">学年学期.</param>
        /// <param name="courseCode">课程代码.</param>
        /// <param name="courseName">课程名称.</param>
        /// <param name="propertyCourse">成绩课程性质.</param>
        /// <param name="propertyGraduation">毕业课程性质.</param>
        /// <param name="credit">学分.</param>
        /// <param name="markTotal">总评成绩.</param>
        /// <param name="propertyExamin">成绩审核属性.</param>
        /// <param name="markTop">最高成绩.</param>
        /// <param name="markFirst">首次成绩.</param>
        /// <param name="examStatus">考试状态.</param>
        /// <param name="gradeType">成绩类型.</param>
        /// <param name="isAgain">是否重修.</param>
        /// <param name="gpa">学分绩点.</param>
        public Grade(
            string yearSemester,
            string courseCode,
            string courseName,
            string propertyCourse,
            string propertyGraduation,
            string credit,
            string markTotal,
            string propertyExamin,
            string markTop,
            string markFirst,
            string examStatus,
            string gradeType,
            string isAgain,
            string gpa)
        {
            this.YearSemester = yearSemester;
            this.CourseCode = courseCode;
            this.CourseName = courseName;
            this.PropertyCourse = propertyCourse;
            this.PropertyGraduation = propertyGraduation;
            this.Credit = credit;
            this.MarkTotal = markTotal;
            this.PropertyExamin = propertyExamin;
            this.MarkTop = markTop;
            this.MarkFirst = markFirst;
            this.ExamStatus = examStatus;
            this.GradeType = gradeType;
            this.IsAgain = isAgain;
            this.GPA = gpa;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade"/> class.
        /// 学年学期
        /// 课程代码
        /// 课程名称
        /// 成绩课程性质
        /// 毕业课程性质
        /// 学分
        /// 总评成绩
        /// 成绩审核属性
        /// 最高成绩
        /// 首次成绩
        /// 考试状态
        /// 成绩类型
        /// 是否重修
        /// 学分绩点.
        /// </summary>
        /// <param name="ls">按顺序写入.</param>
        public Grade(List<string> ls)
        {
            this.YearSemester = ls[0];
            this.CourseCode = ls[1];
            this.CourseName = ls[2];
            this.PropertyCourse = ls[3];
            this.PropertyGraduation = ls[4];
            this.Credit = ls[5];
            this.MarkTotal = ls[6];
            this.PropertyExamin = ls[7];
            this.MarkTop = ls[8];
            this.MarkFirst = ls[9];
            this.ExamStatus = ls[10];
            this.GradeType = ls[11];
            this.IsAgain = ls[12];
            this.GPA = ls[13];
        }

        /// <summary>
        /// Gets or sets 学年学期.
        /// </summary>
        public string YearSemester { get; set; }

        /// <summary>
        /// Gets or sets 课程代码.
        /// </summary>
        public string CourseCode { get; set; }

        /// <summary>
        /// Gets or sets 课程名称.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets 成绩课程性质.
        /// </summary>
        public string PropertyCourse { get; set; }

        /// <summary>
        /// Gets or sets 毕业课程性质.
        /// </summary>
        public string PropertyGraduation { get; set; }

        /// <summary>
        /// Gets or sets 学分.
        /// </summary>
        public string Credit { get; set; }

        /// <summary>
        /// Gets or sets 总评成绩.
        /// </summary>
        public string MarkTotal { get; set; }

        /// <summary>
        /// Gets or sets 成绩审核属性.
        /// </summary>
        public string PropertyExamin { get; set; }

        /// <summary>
        /// Gets or sets 最高成绩.
        /// </summary>
        public string MarkTop { get; set; }

        /// <summary>
        /// Gets or sets 首次成绩.
        /// </summary>
        public string MarkFirst { get; set; }

        /// <summary>
        /// Gets or sets 考试状态.
        /// </summary>
        public string ExamStatus { get; set; }

        /// <summary>
        /// Gets or sets 成绩类型.
        /// </summary>
        public string GradeType { get; set; }

        /// <summary>
        /// Gets or sets 是否重修.
        /// </summary>
        public string IsAgain { get; set; }

        /// <summary>
        /// Gets or sets 学分绩点.
        /// </summary>
        public string GPA { get; set; }
    }
}
