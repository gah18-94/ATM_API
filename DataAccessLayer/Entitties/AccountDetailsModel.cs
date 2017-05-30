using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_API.Models
{
    public class AccountDetailsModel
    {
        [Key]
        public int Id_Account { get; set; }
        public int Id_User { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set;}
        public ICollection<TransactionHistoryModel> TransactionHistory { get; set; }
    }
}
