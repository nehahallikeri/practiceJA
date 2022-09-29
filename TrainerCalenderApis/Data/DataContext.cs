using Microsoft.EntityFrameworkCore;

namespace TrainerCalenderApis.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<TrainerCourse> TrainerCourses { get; set; }
        public DbSet<Schedule> Schedules  { get; set; }
    }
}
