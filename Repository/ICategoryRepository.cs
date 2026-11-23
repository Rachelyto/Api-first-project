using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
