using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_API.Models
{
    public class TransactionHistoryModel
    {
        public int Id_Transaction { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public string Description { get; set; }
    }
}
