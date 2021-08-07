using System;
using System.Collections.Generic;
using System.Text;

namespace ISTore.Entity
{
    public class Category:BaseEntity
    {
        public List<Product> Products { get; set; }
    }
}
