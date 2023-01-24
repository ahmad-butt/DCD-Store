using System;
namespace DCD_Store.Models
{
	public class UserRepository
	{
		List<User> users = new List<User>();
		public User CreateUser(string username, string email, string passwd, int age, string phone)
		{
			User newUser = new User
            {
                Id = 1,
                Username = username,
                Email = email,
                Password = passwd,
                Age = age,
                Phone = phone
            };
            users.Add(newUser);
            return newUser;
		}
	}
}

