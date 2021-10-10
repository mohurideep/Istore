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

        public List<Product> GetProduct(string search,int pageNo)
        {
            int pageSize = 5;
            if (!String.IsNullOrEmpty(search))
            {
                return _storeContext.Products
                    .Include(x => x.Category)
                    .Where(x => x.Name != null && x.Name.ToLower()
                    .Contains(search))
                    .OrderBy(x => x.ID)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                return _storeContext.Products.Include(x => x.Category)
                    .OrderBy(x => x.ID)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public List<Product> GetProduct(List<int> productId)
        {
            return _storeContext.Products.Where(x => productId.Contains(x.ID)).ToList();
        }
        public int GetProductCount(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return _storeContext.Products
                    .Include(x => x.Category)
                    .Where(x => x.Name != null && x.Name.ToLower()
                    .Contains(search))
                    .Count();
            }
            else
            {
                return _storeContext.Products.Count();
            }
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
            return _storeContext.Products.Include(x => x.Category).Where(x => x.ID == ID).FirstOrDefault();
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
