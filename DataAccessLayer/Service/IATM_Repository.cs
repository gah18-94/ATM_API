using ATM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public interface IATM_Repository
    {
        UserModel GetDataUser(string username, string password);
        bool UserExist(string username, string password);
        object[] GetAccountsDropDown(int id_user);
        string GetUserID(string username, string password);
        AccountDetailsModel[] GetAccountDetails(int id_user);
        TransactionHistoryModel[] GetTransactionHistory(int id_account, DateTime start, DateTime end);
        bool AvailableMoney(int id_account, decimal amount);
        bool DispenseMoney(int id_account, decimal amount, string description);
    }
}
