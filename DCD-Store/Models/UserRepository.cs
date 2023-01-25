using System;
using System.Linq;
namespace DCD_Store.Models
{
	public class UserRepository
	{
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
	}
}

