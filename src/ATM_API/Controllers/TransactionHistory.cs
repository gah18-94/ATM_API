using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DataAccessLayer.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{

    [EnableCors("AllOrigin")]
    [Route("api/Users/{username}/{password}/Accounts/TransactionHistory/")]
    public class TransactionHistory : Controller
    {
        private IATM_Repository repo;

        public TransactionHistory(IATM_Repository _repo)
        {
            repo = _repo;
        }

        [HttpGet("{Id_Account}/{StartDate}/{EndDate}")]
        public IActionResult GetTransactionHistory(string username, string password, string Id_Account, DateTime StartDate, DateTime EndDate)
        {

            try
            {
                 
                if (!repo.UserExist(username, password))
                {
                    return BadRequest("Wrong username or password, please try again");
                }
                else
                {
                    var account = repo.GetTransactionHistory(Int16.Parse(Id_Account), StartDate, EndDate);
                    if (account.Length > 0)
                    {
                        return Ok(account);
                    }
                    else
                    {
                        return BadRequest("There aren't accounts for the user.");
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Dispense/{Id_Account}/{Amount}/{Description}")]
        public IActionResult Dispense(string username, string password, int Id_Account, decimal Amount, string Description)
        {
            try
            {
                if (repo.AvailableMoney(Id_Account, Amount))
                {
                    var response = repo.DispenseMoney(Id_Account, Amount, Description);
                    if (response)
                    {
                        return Ok("Transaction succesfully added.");
                    }
                    else
                    {
                        return BadRequest("Transaction failed.");
                    }
                }
                else
                {
                    return BadRequest("There aren't enough money in the account.");
                }


            }
            catch (Exception)
            {
                throw;
            }
            

        }




    }
}
