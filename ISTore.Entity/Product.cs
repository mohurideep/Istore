﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ISTore.Entity
{
    public class Product:BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
