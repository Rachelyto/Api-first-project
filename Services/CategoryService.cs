using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repository.GetAllCategories();
        }
    }
}
