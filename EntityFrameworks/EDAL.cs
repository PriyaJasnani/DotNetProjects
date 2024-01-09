using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsJuly
{
    public class EDAL: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            optionsBuilder.UseSqlServer(ConnectionString);
        }
       
       public DbSet<BookMaster>books { get; set; }
        

    }
}
