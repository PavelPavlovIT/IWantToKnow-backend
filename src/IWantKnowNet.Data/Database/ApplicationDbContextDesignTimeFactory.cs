using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IWantKnowNet.Data.Database
{
    public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySQL("server=localhost;database=db-dev;user=root;password=7oMfdCXUBPSKVoaF3shk");
            // optionsBuilder.UseMySQL("server=localhost;database=db-test;user=root;password=7oMfdCXUBPSKVoaF3shk");
            // optionsBuilder.UseMySQL("server=db1.c12mwko402s6.sa-east-1.rds.amazonaws.com;database=db-prod;user=admin;password=7oMfdCXUBPSKVoaF3shk");


            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}