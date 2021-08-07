using ISTore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IStore.Database
{
    public class IStoreContext:DbContext
    {
        public IStoreContext(DbContextOptions<IStoreContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
