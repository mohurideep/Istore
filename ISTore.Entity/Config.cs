using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IStore.Entity
{
    public class Config
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
