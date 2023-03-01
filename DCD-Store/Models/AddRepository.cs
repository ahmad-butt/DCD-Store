using System;
using System.Linq;
using System.Numerics;
using DCD_Store.Models.Interfces;

namespace DCD_Store.Models
{
	public class AddRepository : IAddRepository
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
        public List<Add> ViewAdds(string category)
        {
            List<Add> adds = new();

            foreach(Add add in context.Adds)
            {
                if(add.Category == category)
                {
                    adds.Add(add);
                }
            }
            return adds;
        }

        public void UpdatePhotoPath(int id, string path)
        {
            Add add = context.Adds.Where<Add>(add=>add.Id == id).ToList()[0];
            add.PhotoPath = path;
            context.SaveChanges();
        }

    }
}

