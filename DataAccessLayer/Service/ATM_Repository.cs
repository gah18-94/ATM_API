using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_API.Models;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Service
{
    public class ATM_Repository : IATM_Repository
    {
        private ATM_context _context;

        public ATM_Repository(ATM_context context)
        {
            _context = context;
        }

        public AccountDetailsModel[] GetAccountDetails(int id_user)
        {
            try
            {
                 var details = from a in _context.AccountDetails
                          where a.Id_User == id_user && a.isActive == true
                          select a;
            return details.ToArray();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TransactionHistoryModel[] GetTransactionHistory(int id_account)
        {
            try
            {
                var history = from h in _context.TransactionHistory
                              where h.Id_Account == id_account
                              select h;
                return history.ToArray();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object[] GetAccountsDropDown(int id_user)
        {
            try
            {
                List<string> result = new List<string>();
                var accounts = from a in _context.AccountDetails
                               where a.Id_User == id_user
                               select new { a.Id_Account, a.Description };


                return accounts.ToArray();
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public UserModel GetDataUser(string username, string password)
        {
            try
            {
                return _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
           
            
        
        }

        public bool UserExist( string username, string password) {
            try
            {
                if (!_context.Users.Any(u => u.Username == username))
                {
                    return false;
                }
                else
                {
                    if (_context.Users.Any(u => u.Username == username && u.Password == password))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

       

        public string GetUserID(string username, string password)
        {
            try
            {
                return _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault().Id_User.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public TransactionHistoryModel[] GetTransactionHistory(int id_account, DateTime start, DateTime end)
        {

            var transactions = from t in _context.TransactionHistory
                               where t.Id_Account == id_account &&
                               (start <= t.TransactionDate && t.TransactionDate <= end)
                               select t;
            return transactions.ToArray();
        }

        public bool AvailableMoney(int id_account, decimal amount)
        {
            try
            {
                SqlDecimal AccountMoney = _context.AccountDetails.Where(a => a.Id_Account==id_account).FirstOrDefault().TotalAmount;
                if (AccountMoney.Value > amount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DispenseMoney(int id_account, decimal amount,string description)
        {
            try
            {
                _context.Database.BeginTransaction();

                SqlDecimal account = _context.AccountDetails.Where(a => a.Id_Account == id_account).FirstOrDefault().TotalAmount;
                account = account - amount;
                _context.SaveChanges();
                if (account>=0) {

                    TransactionHistoryModel hist = new TransactionHistoryModel { };
                    hist.Description = description;
                    hist.TransactionAmount = amount;
                    hist.Id_Account = id_account;
                    hist.TransactionDate = DateTime.Today;
                    hist.TransactionType = "ATM transaction.";
                    _context.TransactionHistory.Add(hist);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    return true;
                }
                else
                {
                    _context.Database.RollbackTransaction();
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
