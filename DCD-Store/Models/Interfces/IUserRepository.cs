using System;
using Microsoft.EntityFrameworkCore;

namespace DCD_Store.Models.Interfces
{
	public interface IUserRepository
	{
        public User? CreateUser(string username, string email, string passwd, int age, string phone);

        public User? Login(string email, string passwd);
    }
}

