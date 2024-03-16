using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;

namespace Ryzhanovskyi.University.Tinder.Web.Data
{
    public class DataContext : DbContext
    {

        public IConfiguration Configuration { get; set; }
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> Users { get; set; }
    }
}
