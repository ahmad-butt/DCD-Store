using System;
using System.Linq;
using System.Numerics;
using Azure.Core;
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

        public List<Add> MyAdds(int id)
        {
            return context.Adds.Where(add => add.UserId == id && add.IsActive).ToList();
        }


        public List<Add> ViewAdds(string category)
        {
            List<Add> adds = new();

            foreach(Add add in context.Adds)
            {
                if(add.Category == category && add.IsActive)
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

        public void RemoveAdd(int id)
        {
            Add add = context.Adds.First(add => add.Id == id);
            add.IsActive = false;
            context.SaveChanges();
        }

        public Add GetAdd(int id)
        {
            return context.Adds.First(add => add.Id==id);
        }

        public void UpdateAdd(Add add)
        {
            Add old_add = context.Adds.First(a => a.Id == add.Id);
            old_add = add;
            context.SaveChanges();
        }

        public List<Add> Top3Adds()
        {
            return context.Adds.Where(a => a.IsActive && a.PhotoPath != null && a.PhotoPath != "").Take(2).ToList();
        }

        public List<Add> SearchAdds(string txt)
        {
            return context.Adds.Where(a => a.Title.Contains(txt) || a.Description.Contains(txt) || a.City.Contains(txt)).ToList();
        }
    }
}

