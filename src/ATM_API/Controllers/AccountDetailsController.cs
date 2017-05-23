using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{
    [Route("api/Users")]
    public class AccountDetailsController : Controller
    {
       
        [HttpGet("{username}/AccountDetails")]
        public IActionResult GetAccountDetails(string username)
        {
            var user = UsersData.current.Users.FirstOrDefault(c => c.Username == username);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.AccountDetails);
        }
       
    }
}
