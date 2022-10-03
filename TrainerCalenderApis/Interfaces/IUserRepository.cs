namespace TrainerCalenderApis.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUser(string email);
        ICollection<Course> GetCourse();
        ICollection<Skill> GetSkill();
        bool UserExists(int id);
    }
}
