using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        _216775882_MyStoreDBContext dbContext;
        public CategoryRepository(_216775882_MyStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
