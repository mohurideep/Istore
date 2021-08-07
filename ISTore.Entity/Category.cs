using System;
using System.Collections.Generic;
using System.Text;

namespace IStore.Entity
{
    public class Category:BaseEntity
    {
        public List<Product> Products { get; set; }
    }
}
