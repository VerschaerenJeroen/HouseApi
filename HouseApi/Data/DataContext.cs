using Microsoft.EntityFrameworkCore;

namespace HouseApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
    }
}
