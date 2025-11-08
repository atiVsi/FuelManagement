using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FuelManagement.DataLayer.Context
{
    public class FuelmanagementContextFactory : IDesignTimeDbContextFactory<FuelmanagementContext>
    {
        public FuelmanagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FuelmanagementContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=FuelManagementDB;Trusted_Connection=True;TrustServerCertificate=True");
            return new FuelmanagementContext(optionsBuilder.Options);
        }
    }
}
