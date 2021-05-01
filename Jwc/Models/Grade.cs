using System.Collections.Generic;

namespace Jwc.Models
{
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
    /// 学分绩点
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// 学年学期
        /// </summary>
        public string YearSemester { get; set; }
        /// <summary>
        /// 课程代码
        /// </summary>
        public string CourseCode { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 成绩课程性质
        /// </summary>
        public string PropertyCourse { get; set; }
        /// <summary>
        /// 毕业课程性质
        /// </summary>
        public string PropertyGraduation { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public string Credit { get; set; }
        /// <summary>
        /// 总评成绩
        /// </summary>
        public string MarkTotal { get; set; }
        /// <summary>
        /// 成绩审核属性
        /// </summary>
        public string PropertyExamin { get; set; }
        /// <summary>
        /// 最高成绩
        /// </summary>
        public string MarkTop { get; set; }
        /// <summary>
        /// 首次成绩
        /// </summary>
        public string MarkFirst { get; set; }
        /// <summary>
        /// 考试状态
        /// </summary>
        public string ExamStatus { get; set; }
        /// <summary>
        /// 成绩类型
        /// </summary>
        public string GradeType { get; set; }
        /// <summary>
        /// 是否重修
        /// </summary>
        public string IsAgain { get; set; }
        /// <summary>
        /// 学分绩点
        /// </summary>
        public string GPA { get; set; }

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
        /// 学分绩点
        /// </summary>
        /// <param name="YearSemester">学年学期</param>
        /// <param name="CourseCode">课程代码</param>
        /// <param name="CourseName">课程名称</param>
        /// <param name="PropertyCourse">成绩课程性质</param>
        /// <param name="PropertyGraduation">毕业课程性质</param>
        /// <param name="Credit">学分</param>
        /// <param name="MarkTotal">总评成绩</param>
        /// <param name="PropertyExamin">成绩审核属性</param>
        /// <param name="MarkTop">最高成绩</param>
        /// <param name="MarkFirst">首次成绩</param>
        /// <param name="ExamStatus">考试状态</param>
        /// <param name="GradeType">成绩类型</param>
        /// <param name="IsAgain">是否重修</param>
        /// <param name="GPA">学分绩点</param>
        public Grade(string YearSemester, string CourseCode,string CourseName, 
            string PropertyCourse, string PropertyGraduation, string Credit, string MarkTotal,
            string PropertyExamin, string MarkTop, string MarkFirst, string ExamStatus,
            string GradeType, string IsAgain, string GPA)
        {
            this.YearSemester = YearSemester;
            this.CourseCode = CourseCode;
            this.CourseName = CourseName;
            this.PropertyCourse = PropertyCourse;
            this.PropertyGraduation = PropertyGraduation;
            this.Credit = Credit;
            this.MarkTotal = MarkTotal;
            this.PropertyExamin = PropertyExamin;
            this.MarkTop = MarkTop;
            this.MarkFirst = MarkFirst;
            this.ExamStatus = ExamStatus;
            this.GradeType = GradeType;
            this.IsAgain = IsAgain;
            this.GPA = GPA;
        }

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
        /// 学分绩点
        /// </summary>
        /// <param name="ls">按顺序写入</param>
        public Grade(List<string> ls)
        {
            YearSemester = ls[0];
            CourseCode = ls[1];
            CourseName = ls[2];
            PropertyCourse = ls[3];
            PropertyGraduation = ls[4];
            Credit = ls[5];
            MarkTotal = ls[6];
            PropertyExamin = ls[7];
            MarkTop = ls[8];
            MarkFirst = ls[9];
            ExamStatus = ls[10];
            GradeType = ls[11];
            IsAgain = ls[12];
            GPA = ls[13];
        }
    }
}
