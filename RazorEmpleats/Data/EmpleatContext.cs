using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorEmpleats.Models;

namespace RazorEmpleats.Data
{
    public class EmpleatContext : DbContext
    {
        public EmpleatContext (DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<RazorEmpleats.Models.EmpleatInfo> EmpleatInfo { get; set; }
    }
}
