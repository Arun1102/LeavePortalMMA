using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;
using LeavePortalMMA.Repositories;
using LeavePortalMMA.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;


namespace LeavePortalMMA.ServiceLayers
{
    //public class CategoryServiceLayer
    //{
        public interface ICategoriesServiceLayer
    {
            void InsertCategory(CategoryViewModel cvm);
            void UpdateCategory(CategoryViewModel cdm);
            void DeleteCategory(int cid);
            List<CategoryViewModel> GetCategories();
            CategoryViewModel GetCategoryByCategoryID(int CategoryID);
        }
        public class CategoriesServiceLayer : ICategoriesServiceLayer
        {
            ICategoryRepository cr;

            public CategoriesServiceLayer()
            {
                cr = new CategoryRepository();
            }

            public void InsertCategory(CategoryViewModel cvm)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Categories>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                Categories c = mapper.Map<CategoryViewModel, Categories>(cvm);
                cr.AddCategory(c);
            }

            public void UpdateCategory(CategoryViewModel cvm)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Categories>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                Categories c = mapper.Map<CategoryViewModel, Categories>(cvm);
                cr.UpdateCategory(c);
            }

            public void DeleteCategory(int cid)
            {
                cr.DeleteCategory(cid);
            }

            public List<CategoryViewModel> GetCategories()
            {
                List<Categories> c = cr.GetCategories();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Categories, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                List<CategoryViewModel> cvm = mapper.Map<List<Categories>, List<CategoryViewModel>>(c);
                return cvm;
            }

            public CategoryViewModel GetCategoryByCategoryID(int CategoryID)
            {
                Categories c = cr.GetCategoriesByCategoryID(CategoryID);
                CategoryViewModel cvm = null;
                if (c != null)
                {
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<Categories, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
                    IMapper mapper = config.CreateMapper();
                    cvm = mapper.Map<Categories, CategoryViewModel>(c);
                }
                return cvm;
            }
        }
    }


