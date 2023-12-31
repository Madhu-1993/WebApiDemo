﻿using WebApiDemo.Model;

namespace WebApiDemo.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        int AddProduct(Product prod);
        int UpdateProduct(Product prod);
        int DeleteProduct(int id);

    }
}
