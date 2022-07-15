using DataAccessLayer;
using EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager
    {
        Repository<Category> caterepo = new Repository<Category>();
        public List<Category> GetAll()
        {
            return caterepo.List();
        }
        //CategoryManager
        public int BLAdd(Category c)
        {
            return caterepo.Insert(c);
        }
        //CategoryManager
        public int BLDell(int p)
        {
            if(p != 0)
            {
                Category c = caterepo.Find(x => x.CategoryID == p);
                return caterepo.Delete(c);
            }
            else
            {
                return -1;
            }
        }
        //CategoryManager
        public int BLUpdate(Category p)
        {
            if(p.CategoryName == "" || p.CategoryName.Length <= 3 || 
                p.CategoryName.Length >= 30)
            {
                return -1;
            }
            Category ct = caterepo.Find(x => x.CategoryID == p.CategoryID);
            ct.CategoryName = p.CategoryName;
            return caterepo.Update(ct);
        }
    }
}
