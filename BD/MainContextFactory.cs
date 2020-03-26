using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace BD
{
    public class MainContextFactory : IDesignTimeDbContextFactory<MainContext>, IDisposable
    {
        public static IConfigurationRoot configuration { get; private set; }

        public MainContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MainContext>();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configurationBuilder = new ConfigurationBuilder();
           

            configuration = configurationBuilder.Build();
            string conexao = @"Server=localhost\SQLEXPRESS;Database=teste_123;Trusted_Connection=True;";
            builder.UseSqlServer(conexao);
            return new MainContext(builder.Options);
        }

        public void Dispose()
        {

        }
    }

}
