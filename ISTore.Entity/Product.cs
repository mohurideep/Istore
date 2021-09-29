using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IStore.Entity
{
    public class Product:BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime EntryDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
