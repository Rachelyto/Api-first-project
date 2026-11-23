using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
