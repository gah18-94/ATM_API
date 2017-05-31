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

        [HttpGet("{username}/{password}/Account")]
        public IActionResult GetAccountsDropDown(string username, string password)
        {
            try
            {
                var Id_user = repo.GetUserID(username, password);

                var accounts = repo.GetAccountsDropDown(Int16.Parse(Id_user));

                return Ok(accounts);
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
                var Id_user = repo.GetUserID(username, password);
                var details = repo.GetAccountDetails(Int16.Parse(Id_user.ToString()));
                return Ok(details);
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
