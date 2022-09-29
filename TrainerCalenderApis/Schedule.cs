using System.ComponentModel.DataAnnotations;

namespace TrainerCalenderApis
{
    public class Schedule
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public DateTime Date { get; set; }
        public int FromTime { get; set; }
        public int ToTime { get; set; }
        public string? Mode { get; set; }
        public string? Location { get; set; }
        [Required]
        public TrainerCourse TrainerCourse { get; set; }
    }
}
