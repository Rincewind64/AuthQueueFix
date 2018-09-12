using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthQueueAppV3.Models;

namespace AuthQueueAppV3.Data
{
    public class FITDbContext : DbContext
    {
        public FITDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<FITQuote_tbl> FITQuote_tbl { get; set; }
        public DbSet<BkgActivityClient_tbl> BkgActivityClient_tbl { get; set; }
    }
}
