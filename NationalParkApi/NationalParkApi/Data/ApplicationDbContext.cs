using Microsoft.EntityFrameworkCore;
using NationalParkApi.Models;

namespace NationalParkApi.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<NationalPark> NationalParks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
