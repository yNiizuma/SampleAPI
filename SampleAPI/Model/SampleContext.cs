using Microsoft.EntityFrameworkCore;

namespace SampleAPI.Model
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }
        public DbSet<Sample> Samples { get; set; }
    }
}
