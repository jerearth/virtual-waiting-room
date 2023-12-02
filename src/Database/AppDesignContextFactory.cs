using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDesignContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string _dummyConnectionString = @"Server=localhost;Database=webapp_db;Uid=root;Pwd=root;";

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(_dummyConnectionString, serverVersion: ServerVersion.AutoDetect(_dummyConnectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
