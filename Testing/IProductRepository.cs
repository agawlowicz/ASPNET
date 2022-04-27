using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //stubbed out method
        public Product GetProduct(int id); // View one product at a time
        public void UpdateProduct(Product product); //update product information
    }
}
