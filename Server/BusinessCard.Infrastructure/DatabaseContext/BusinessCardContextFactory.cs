//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;


//namespace BusinessCard.Infrastructure.DatabaseContext
//{

//    public class BusinessCardContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                                               .SetBasePath(Directory.GetCurrentDirectory())
//                                               .AddJsonFile("appsettings.json")
//                                               .Build();

//            string conn = configuration.GetConnectionString("Default");
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

//            return new ApplicationDbContext(optionsBuilder.Options);
//        }
//    }
   
//}
