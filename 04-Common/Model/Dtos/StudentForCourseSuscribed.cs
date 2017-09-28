using System;

namespace Model.Dtos
{
    public class StudentForCourseSuscribed
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool Suscribed { get; set; }
    }
}
