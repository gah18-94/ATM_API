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

        [HttpPost("/{username}/{password}/Dispense/{Id_Account}/{Amount}")]
        public async Task<IActionResult>  Dispense(string username, string password, string Id_Account, double amount)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }

            return BadRequest("Failed to save");
        
    }   



        
    }
}
