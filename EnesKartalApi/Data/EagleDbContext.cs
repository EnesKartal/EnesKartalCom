using Microsoft.EntityFrameworkCore;

namespace EnesKartalApi.Data
{
    public class EagleDbContext : DbContext
    {
        public EagleDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CopyDuplicatorLicence> CopyDuplicatorLicence { get; set; }
    }
}
