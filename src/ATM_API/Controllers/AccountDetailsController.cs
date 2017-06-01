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
    [Route("api/Users/")]
    public class AccountDetailsController : Controller
    {
        private IATM_Repository repo;

        public AccountDetailsController(IATM_Repository _repo)
        {
            repo = _repo;
        }

        [HttpGet("{username}/{password}/Accounts")]
        public IActionResult GetAccountsDropDown(string username, string password)
        {
            try
            {
                if (!repo.UserExist(username, password))
                {
                    return BadRequest("Wrong username or password, please try again.");
                }
                else
                {
                    
                    var Id_user = repo.GetUserID(username, password);

                    var accounts = repo.GetAccountsDropDown(Int16.Parse(Id_user));
                    if(accounts.Length > 0)
                    {
                        return Ok(accounts);
                    }
                    else
                    {
                        return BadRequest("There aren't transactions for the account.");
                    }

                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{username}/{password}/AccountDetails")]
        public IActionResult GetAccountDetails(string username, string password)
        {
            try
            {
                if (!repo.UserExist(username, password))
                {
                    return BadRequest("Wrong username or password, please try again.");
                }
                else
                {
                    var Id_user = repo.GetUserID(username, password);
                    var details = repo.GetAccountDetails(Int16.Parse(Id_user.ToString()));
                    if (details.Length >= 0)
                    {
                        return Ok(details);
                    }
                    else
                    {
                        return BadRequest("There aren't account information for the user.");
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
