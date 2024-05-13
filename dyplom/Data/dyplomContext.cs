using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dyplom.Models;

namespace dyplom.Data
{
    public class dyplomContext : DbContext
    {
        public dyplomContext (DbContextOptions<dyplomContext> options)
            : base(options)
        {
        }

        public DbSet<dyplom.Models.User> User { get; set; } = default!;
    }
}
