using System.Text.Json.Serialization;

namespace TrainerCalenderApis
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
    }
}
