using Microsoft.EntityFrameworkCore;
using dotNetBasic.Models;

namespace dotNetBasic.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books  => Set<Book>();
    }
}