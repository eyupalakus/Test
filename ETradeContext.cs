using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Test
{
    public class ETradeContext : DbContext
    {
        public DbSet<Product> products { get; set; }
    }
}
