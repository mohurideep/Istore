using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string imageURL { get; set; }
        public int CategoryID { get; set; }
    }

    public class CategorySearchViewModel
    {
        public List<Category> Categories { get; set; }
        public string SearchTerm { get; set; }

        //public Pager Pager { get; set; }
    }
}
