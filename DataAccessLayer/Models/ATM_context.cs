using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATM_API.Models;

namespace DataAccessLayer.Models
{
    public class ATM_context : DbContext

    {
        public ATM_context()
        {

        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<AccountDetailsModel> AccountDetails { get; set; }
        public DbSet<TransactionHistoryModel> TransacionHistorys{ get; set; }

    }
}
