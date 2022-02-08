using FluentNHibernate.Conventions.Inspections;
using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using Market.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Sevices
{

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public bool AddCategory(Category category)
        {
            bool res = false;
            try
            {
                if (!string.IsNullOrEmpty(category.Name))
                {
                    _categoryRepository.Add(category);
                    res = true;
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.Get();
        }

        public Category GetCategory(int id)
        {
            try
            {
                var category = _categoryRepository.Get(id);
                return category;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCategory(Category category)
        {
            bool res = false;
            try
            {
                var iscategory = _categoryRepository.Get(category.Id);
                if (iscategory != null)
                {
                    _categoryRepository.Update(category);
                    res = true;
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

