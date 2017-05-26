using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATM_API.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Models
{
    public class ATM_context : DbContext

    {
        private IConfigurationRoot _config;

        public ATM_context(IConfigurationRoot config, DbContextOptions options)
        {
            _config = config;
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<AccountDetailsModel> AccountDetails { get; set; }
        public DbSet<TransactionHistoryModel> TransacionHistorys{ get; set; }

    }
}
