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
    [Route("api/Users/")]
    public class AccountDetailsController : Controller
    {
        private IATM_Repository repo;
        private ILogger logger;

        public AccountDetailsController(IATM_Repository _repo, ILogger<TransactionHistory> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        [HttpGet("{username}/{password}/Accounts")]
        public IActionResult GetAccountsDropDown(string username, string password)
        {
            try
            {
                
                if (!repo.UserExist(username, password))
                {
                    logger.LogInformation($"Attemp failed to GetAccountsDropDown for the user:{username} with password :{password}");
                    return BadRequest("Wrong username or password, please try again.");
                }
                else
                {
                    
                    var Id_user = repo.GetUserID(username, password);

                    var accounts = repo.GetAccountsDropDown(Int16.Parse(Id_user));
                    if(accounts.Length > 0)
                    {
                        logger.LogInformation($"GetAccountsDropDown OK for the user:{username} with password :{password}");
                        return Ok(accounts);
                    }
                    else
                    {
                        logger.LogInformation($"There aren't accounts on GetAccountsDropDown for the user:{username} with password :{password}");
                        return BadRequest("There aren't accounts for the user.");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"GetAccountsDropDown error:_{ex}_");
                return BadRequest("Error.");
            }
        }
        [HttpGet("{username}/{password}/AccountDetails")]
        public IActionResult GetAccountDetails(string username, string password)
        {
            try
            {
                if (!repo.UserExist(username, password))
                {
                    logger.LogInformation($"Attemp failed to GetAccountDetails for the user:{username} with password :{password}");
                    return BadRequest("Wrong username or password, please try again.");
                }
                else
                {
                    var Id_user = repo.GetUserID(username, password);
                    var details = repo.GetAccountDetails(Int16.Parse(Id_user.ToString()));
                    if (details.Length >= 0)
                    {
                        logger.LogInformation($"GetAccountDetails OK for the user:{username} with password :{password}");
                        return Ok(details);
                    }
                    else
                    {
                        logger.LogInformation($"There aren't account information on GetAccountDetails OK for the user:{username} with password :{password}");
                        return BadRequest("There aren't account information for the user.");
                    }
                }
                
            }
            catch (Exception ex)
            {

                logger.LogError($"GetAccountDetails error:_{ex}_");
                return BadRequest("Error.");
            }
        }
       
    }
}
