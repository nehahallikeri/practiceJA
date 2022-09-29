﻿namespace TrainerCalenderApis
{
    public class TrainerCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
