using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Category> FeaturedCategories { get; set; }
    }
}
