using IStore.Database;
using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IStore.Services
{
    public class CategoriesService
    {
        private readonly IStoreContext _storeContext;

        public CategoriesService(IStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Category> GetCategory()
        {
            return _storeContext.Categories.ToList();
        }
        public void SaveCategory(Category category)
        {
            _storeContext.Categories.Add(category);
            _storeContext.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            var CategoryById = _storeContext.Categories.FirstOrDefault(x => x.ID == category.ID);
            CategoryById.Name = category.Name;
            CategoryById.Description = category.Description;
            CategoryById.ImageURL = category.ImageURL;
            _storeContext.SaveChanges();
        }
        public Category FindCategory(int ID)
        {
            return _storeContext.Categories.Find(ID);
        }
        public void DeleteCategory(int ID)
        {
            var data = _storeContext.Categories.Find(ID);
            _storeContext.Categories.Remove(data);
            _storeContext.SaveChanges();
        }
    }
}
