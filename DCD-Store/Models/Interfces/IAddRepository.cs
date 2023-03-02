using System;
using Microsoft.EntityFrameworkCore;

namespace DCD_Store.Models.Interfces
{
	public interface IAddRepository
	{
        public Add PostAdd(int uid, string title, string description, string city, string category);

        public List<Add> ViewAdds(string category);

        public void UpdatePhotoPath(int uid, string path);
        List<Add> MyAdds(int v);
        void RemoveAdd(int id);
        Add GetAdd(int id);
        void UpdateAdd(Add add);
        List<Add> Top3Adds();
        List<Add> SearchAdds(string txt);
    }
}

