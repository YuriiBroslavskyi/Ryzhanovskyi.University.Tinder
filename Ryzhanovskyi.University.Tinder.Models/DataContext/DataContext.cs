using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Ryzhanovskyi.University.Tinder.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
