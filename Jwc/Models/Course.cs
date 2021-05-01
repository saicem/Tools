using System;

namespace Jwc.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public string Room { get; set; }
        public int WeekStart { get; set; }
        public int WeekEnd { get; set; }

        public int WeekSpan { get { return WeekEnd - WeekStart + 1; } }
        public int SectionStart { get; set; }
        public int SectionEnd { get; set; }
        /// <summary>
        /// 总共几节小课
        /// </summary>
        public int ClassSpan { get { return SectionEnd - SectionStart + 1; } }
        /// <summary>
        /// 大课时间
        /// </summary>
        public int Section { get { return GetSection(SectionStart); } }
        public DayOfWeek DayOfWeek { get; set; }
        public string Teacher { get; set; }
        public string Credit { get; set; }
        public string Status { get; set; }//是否评教

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
