using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;

namespace LeavePortalMMA.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Categories ca);
        void UpdateCategory(Categories ca);
        void DeleteCategory(int id);
        List<Categories> GetCategories();
        Categories GetCategoriesByCategoryID(int id);
            
    }
    public class CategoryRepository:ICategoryRepository
    {
        LeavePortalMMADatabaseDbcontext db;
        public CategoryRepository()
        {
            db = new LeavePortalMMADatabaseDbcontext();
        }
        public void AddCategory(Categories ca)
        {
            db.Category.Add(ca);
            db.SaveChanges();
        }

        public void UpdateCategory(Categories ca)
        {
            Categories cu = db.Category.Where(temp => temp.CategoryID == ca.CategoryID).FirstOrDefault();
            if (cu != null)
            {
                cu.CategoryName = ca.CategoryName;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            Categories c = db.Category.Where(temp => temp.CategoryID == id).FirstOrDefault();
            if(c != null)
            {
                db.Category.Remove(c);
                db.SaveChanges();
            }
        }

        public List<Categories> GetCategories()
        {
            List<Categories> c = db.Category.ToList();
            return c;
        }

        public Categories GetCategoriesByCategoryID(int id)
        {
            Categories c = db.Category.Where(temp => temp.CategoryID == id).FirstOrDefault();
            return c;
        }


    }
}
