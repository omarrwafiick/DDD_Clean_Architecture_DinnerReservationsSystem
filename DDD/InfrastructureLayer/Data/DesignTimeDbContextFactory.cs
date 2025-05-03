using InfrastructureLayer.Data;
using InfrastructureLayer.Interceptors;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer("Server=DESKTOP-BAUHCE7\\SQLEXPRESS;Database=DinnerDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");

        return new ApplicationDbContext(optionsBuilder.Options, new PublishDomainEventInterceptors());
    }
}