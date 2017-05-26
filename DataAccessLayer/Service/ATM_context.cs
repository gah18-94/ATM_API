using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATM_API.Models;
using Microsoft.Extensions.Configuration;

<<<<<<< HEAD:DataAccessLayer/Service/ATM_context.cs
namespace DataAccessLayer.Service
=======
namespace DataAccessLayer
>>>>>>> 18bf031ccf7906fbe3f10a1bdd66b3cf693d90ce:DataAccessLayer/Service/ATM_context.cs
{
    public class ATM_context : DbContext

    {
        private IConfigurationRoot _config;
<<<<<<< HEAD:DataAccessLayer/Service/ATM_context.cs
        public ATM_context(IConfigurationRoot config,DbContextOptions<ATM_context> options ) 
=======
        protected ATM_context(IConfigurationRoot config,DbContextOptions<ATM_context> options ) 
>>>>>>> 18bf031ccf7906fbe3f10a1bdd66b3cf693d90ce:DataAccessLayer/Service/ATM_context.cs
            :base(options)
        {
            _config = config;
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<AccountDetailsModel> AccountDetails { get; set; }
        public DbSet<TransactionHistoryModel> TransactionHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ATMConnection"]);
        }


    }
}
