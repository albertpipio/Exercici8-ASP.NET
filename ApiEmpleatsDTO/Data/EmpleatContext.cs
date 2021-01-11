using Microsoft.EntityFrameworkCore;
using ApiEmpleatsDTO.Models;

namespace ApiEmpleatsDTO.Data
{
    public class EmpleatContext : DbContext
    {
        public EmpleatContext(DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleatInfo> EmpleatsInfo { get; set; }
    }
}