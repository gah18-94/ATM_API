using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DataAccessLayer.Service;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{

    [EnableCors("AllOrigin")]
    [Route("api/Users/{username}/{password}/Accounts/TransactionHistory/")]
    public class TransactionHistory : Controller
    {
        private IATM_Repository repo;
        private ILogger logger;

        public TransactionHistory(IATM_Repository _repo, ILogger<TransactionHistory> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        [HttpGet("{Id_Account}/{StartDate}/{EndDate}")]
        public IActionResult GetTransactionHistory(string username, string password, string Id_Account, DateTime StartDate, DateTime EndDate)
        {

            try
            {
                 
                if (!repo.UserExist(username, password))
                {
                    logger.LogInformation($"Attemp failed to GetTransactionHistory with Id_Account:{Id_Account}, usr:{username}, pwd:{password},sd:{StartDate},ed:{EndDate}");
                    return BadRequest("Wrong username or password, please try again");
                }
                else
                {
                    var account = repo.GetTransactionHistory(Int16.Parse(Id_Account), StartDate, EndDate);
                    if (account.Length > 0)
                    {
                        logger.LogInformation($"GetTransactionHistory OK with Id_Account:{Id_Account}, usr:{username}, pwd:{password},sd:{StartDate},ed:{EndDate}");
                        return Ok(account);
                    }
                    else
                    {
                        logger.LogInformation($"There aren't records on GetTransactionHistory with Id_Account:{Id_Account}, usr:{username}, pwd:{password},sd:{StartDate},ed:{EndDate}");
                        return BadRequest("There aren't accounts for the user.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError($"Error on GetTransactionHistory: _{ex}_");
                return BadRequest("Error.");
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
                        logger.LogInformation($"Dispense money OK with Id_Account:{Id_Account}, usr:{username},am:{Amount},desc:{Description}");
                        return Ok("Transaction succesfully.");
                    }
                    else
                    {
                        logger.LogInformation($"Dispense money Failed with Id_Account:{Id_Account}, usr:{username}, am:{Amount},desc:{Description}");
                        return BadRequest("Transaction failed.");
                    }
                }
                else
                {
                    logger.LogInformation($"There aren't enough money on Dispense money with Id_Account:{Id_Account}, usr:{username}, am:{Amount},desc:{Description}");
                    return BadRequest("There aren't enough money in the account.");
                }


            }
            catch (Exception ex )
            {
                logger.LogError($"Error on Dispense method:_{ex}_");
                return BadRequest("Error");
            }
            

        }




    }
}
