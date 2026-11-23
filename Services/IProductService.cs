using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
