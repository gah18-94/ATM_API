using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{

    [EnableCors("AllOrigin")]
    [Route("api/Users")]
    public class AccountDetailsController : Controller
    {
       
        [HttpGet("{username}/{password}/AccountDetails")]
        public IActionResult GetAccountDetails(string username,string password)
        {
            var user = UsersData.current.Users.FirstOrDefault(c => c.Username == username & c.Password == password);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.AccountDetails);
        }
       
    }
}
