namespace Jwc.Models
{
    /// <summary>
    /// 教务处消息提醒中的考试消息
    /// </summary>
    public class Exam
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }

        public Exam(string Name, string Course, string Time, string Place)
        {
            this.Name = Name;
            this.Course = Course;
            this.Time = Time;
            this.Place = Place;
        }
    }
}