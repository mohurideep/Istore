using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Models.ViewModel
{
    public class CheckOutViewModel
    {
        public List<Product> CartProducts { get; set; }

        public List<int> CartProductIds { get; set; }
    }
}
