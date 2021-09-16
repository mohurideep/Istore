using IStore.Database;
using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _storeContext.Products.ToList();
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
    }
}
