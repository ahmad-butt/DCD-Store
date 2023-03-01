using System;
using System.Linq;
using DCD_Store.Models.Interfces;

namespace DCD_Store.Models
{
	public class UserRepository : IUserRepository
	{
        DcdStoreContext context;
        public UserRepository()
        {
            context = new DcdStoreContext();
        }
		public User? CreateUser(string username, string email, string passwd, int age, string phone)
		{
            DcdStoreContext context = new DcdStoreContext();

            int count = context.Users.Where(user=>user.Email == email).Count();

            if (count == 0)
            {
                User newUser = new User
                {
                    Username = username,
                    Email = email,
                    Password = passwd,
                    Age = age,
                    Phone = phone
                };

                context.Add(newUser);
                context.SaveChanges();

                return newUser;
            } else
            {
                return null;
            }
		}

        public User? Login(string email, string passwd)
        {
            List<User> u = context.Users.Where(u => (u.Email == email && u.Password == passwd)).ToList();
            if(u.Count()>0)
                return u[0];
            else
                return null;
        }
	}
}

