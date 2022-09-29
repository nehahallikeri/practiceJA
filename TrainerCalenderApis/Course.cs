using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrainerCalenderApis
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Skill Skill { get; set; }

        public int SkillId { get; set; }
    }
}
