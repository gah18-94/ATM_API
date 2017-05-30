using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_API.Models
{
    public class TransactionHistoryModel
    {
        [Key]
        public int Id_Transaction { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public string Description { get; set; }
        public int Id_Account { get; set; }
    }
}
