using Microsoft.EntityFrameworkCore;
using EntitiesUCM;

namespace DbUCM
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<UserUCM> UsersUCM { get; set; }
    }
}