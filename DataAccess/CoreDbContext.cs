using Microsoft.EntityFrameworkCore;
using PostgresApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresApi.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Item> Items { get; set; }
    }
}
