using System;
using Microsoft.EntityFrameworkCore;

namespace DCD_Store.Models.Interfces
{
	public interface IAddRepository
	{
        public Add PostAdd(int uid, string title, string description, string city, string category);

        public List<Add> ViewAdds(string category);

        public void UpdatePhotoPath(int uid, string path);
    }
}

