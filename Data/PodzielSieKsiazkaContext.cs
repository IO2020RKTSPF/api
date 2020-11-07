using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class PodzielSieKsiazkaContext : DbContext
    {
        public PodzielSieKsiazkaContext(DbContextOptions<PodzielSieKsiazkaContext>opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}