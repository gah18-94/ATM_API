using ATM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_API
{
    public class UsersData
    {
        public static UsersData current { get; } = new UsersData();

        public List<UserModel> Users { get; set; }

        public UsersData()
        {
            Users = new List<UserModel>()
            {
                new UserModel()
                {
                    Id_User = 1,
                    Username="galpizar",
                    Password ="123456",
                    FullName="Gustavo Alpizar Herrera",
                    AccountDetails = new List<AccountDetailsModel>()
                    {
                        new AccountDetailsModel()
                        {
                            Id_Account=1,
                            Description = "First Account",
                            CurrencyType="Dollar",
                            CreatedDate = DateTime.Today,
                            isActive=true,
                            TotalAmount=1250000.98,
                            TransactionHistory = new List<TransactionHistoryModel>()
                            {
                                new TransactionHistoryModel()
                                {
                                    Id_Transaction = 1,
                                    TransactionAmount=5000.98,
                                    TransactionDate=DateTime.Parse( "2017/08/09"),
                                    TransactionType="Telephone Debit",
                                    Description="Montly telephone payment"

                                }
                            }
                        },
                        new AccountDetailsModel()
                        {
                            Id_Account=2,
                            Description = "Second Account",
                            CurrencyType="Dollar",
                            CreatedDate = DateTime.Today,
                            isActive=true,
                            TotalAmount=1250000.98,
                            TransactionHistory = new List<TransactionHistoryModel>()
                            {
                                new TransactionHistoryModel()
                                {
                                    Id_Transaction = 1,
                                    TransactionAmount=5000.98,
                                    TransactionDate=DateTime.Parse( "2017/08/09"),
                                    TransactionType="Telephone Debit",
                                    Description="Montly telephone payment"

                                }
                            }
                        }
                    }

                },
                new UserModel()
                 {
                    Id_User =2,
                    Username="test",
                    Password ="123456",
                    FullName="Test Test Test"

                }
            };
        }
    }
}
