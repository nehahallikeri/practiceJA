using TrainerCalenderApis.Interfaces;

namespace TrainerCalenderApis.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context=context;
        }

        public ICollection<Course> GetCourse()
        {
            throw new NotImplementedException();
        }

        public ICollection<Skill> GetSkill()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
           var user= _context.Users.FirstOrDefault(u => u.ID==id);
            return user;
        }

        public User GetUser(string email)
        {
            return _context.Users.FirstOrDefault(u=> u.Email== email);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();    
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p=> p.ID ==  id);
        }
    }
}
