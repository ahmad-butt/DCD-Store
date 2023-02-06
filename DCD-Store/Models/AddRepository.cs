using System;
using System.Linq;
using System.Numerics;
using post_add.Models;

namespace DCD_Store.Models
{
	public class AddRepository
	{
        DcdStoreContext context;
        public AddRepository()
        {
            context = new DcdStoreContext();
        }


        public Add PostAdd(int uid, string title, string description, string city, string category)
        {
            Add newAdd = new Add
            {
                UserId = uid,
                Title = title,
                Description = description,
                City = city,
                Category = category,
            };

            context.Add(newAdd);
            context.SaveChanges();

            return newAdd;
        }


	}
}

