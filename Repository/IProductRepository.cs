using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
