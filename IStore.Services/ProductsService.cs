using IStore.Database;
using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace IStore.Services
{
    public class ProductsService
    {
        private readonly IStoreContext _storeContext;

        public ProductsService(IStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Product> GetProduct()
        {
            return _storeContext.Products.Include(x => x.Category).ToList();
        }
        public List<Product> GetProduct(List<int> productId)
        {
            return _storeContext.Products.Where(x => productId.Contains(x.ID)).ToList();
        }
        public void SaveProduct(Product product)
        {
            _storeContext.Products.Add(product);
            _storeContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var ProductById = _storeContext.Products.FirstOrDefault(x => x.ID == product.ID);
            ProductById.Name = product.Name;
            ProductById.Description = product.Description;
            ProductById.Price = product.Price;
            ProductById.ImageURL = product.ImageURL;
            _storeContext.SaveChanges();
        }
        public Product FindProduct(int ID)
        {
            return _storeContext.Products.Find(ID);
        }
        public void DeleteProduct(int ID)
        {
            var data = _storeContext.Products.Find(ID);
            _storeContext.Products.Remove(data);
            _storeContext.SaveChanges();
        }

        public List<Product> GetNewProducts()
        {
            return _storeContext.Products.OrderByDescending(x => x.EntryDate).ToList();
        }
    }
}
