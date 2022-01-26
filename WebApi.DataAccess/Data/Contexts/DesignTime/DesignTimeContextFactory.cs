using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Config;

namespace WebApi.DataAccess.Data.Contexts.DesignTime
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<AdministationDbContext>
    {
        //const string EnvAdminDbConnectionString = "WebApiAdminDbConnectionString";

        //private static DbContextOptionsBuilder<T> SetupOptions<T>(string envConnectionString) where T : DbContext
        //{
        //    // set first the envvariable for the connection string to be used when run migrations!!!
        //    // run the following command WITH THE RIGHT CONN STRING
        //    // $env:WebApiAdminDbConnectionString = "Server=PC310094\SQLEXPRESS;Database=webapi_administation;User Id=sorinbtest;MultipleActiveResultSets=false;Encrypt=False;Application Name=WebApi;Password=Password123!@#"
        //    var connectionString = Environment.GetEnvironmentVariable(envConnectionString);
        //    if (string.IsNullOrEmpty(connectionString))
        //        throw new Exception($"Please set connection string via environment variable '{envConnectionString}. \nAlso.. try not to run live migrations against live db, run dotnet ef ... script to examine them first!");

        //    var optionsBuilder = new DbContextOptionsBuilder<T>().UseSqlServer(connectionString);
        //    optionsBuilder.LogTo(x => Console.WriteLine($"debug: {x}"));
        //    optionsBuilder.EnableSensitiveDataLogging();
        //    return optionsBuilder;
        //}

        //AdministationDbContext IDesignTimeDbContextFactory<AdministationDbContext>.CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = SetupOptions<AdministationDbContext>(EnvAdminDbConnectionString);
        //    return new AdministationDbContext(optionsBuilder.Options);
        //}

        private static DbContextOptionsBuilder<T> SetupOptionsWithoutEnv<T>(string connectionString) where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>().UseSqlServer(connectionString);
            optionsBuilder.LogTo(x => Console.WriteLine($"debug: {x}"));
            optionsBuilder.EnableSensitiveDataLogging();
            return optionsBuilder;
        }

        AdministationDbContext IDesignTimeDbContextFactory<AdministationDbContext>.CreateDbContext(string[] args)
        {
            // use the following command (send the connection string through args) before run the migration
            // update-database -args 'Server=PC310094\SQLEXPRESS;Database=webapi_administation;User Id=sorinbtest;MultipleActiveResultSets=false;Encrypt=False;Application Name=WebApi;Password=Password123!@#'

            if (string.IsNullOrEmpty(args[0]))
                throw new Exception($"Please set connection string via command line args '{args[0]}'. \nAlso.. try not to run live migrations against live db, run dotnet ef ... script to examine them first!");

            string connectionString = string.Join(" ", args);

            var optionsBuilder = SetupOptionsWithoutEnv<AdministationDbContext>(connectionString);
            return new AdministationDbContext(optionsBuilder.Options);
        }
    }
}
