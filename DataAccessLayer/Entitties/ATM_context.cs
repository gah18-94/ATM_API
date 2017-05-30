using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATM_API.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class ATM_context : DbContext

    {
        public ATM_context(DbContextOptions<ATM_context> options ) 
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountDetailsModel> AccountDetails { get; set; }
        public DbSet<TransactionHistoryModel> TransactionHistory { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ATMConnection"]);
        }*/


    }
}
