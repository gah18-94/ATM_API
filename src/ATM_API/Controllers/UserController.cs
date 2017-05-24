using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{
    [Route("api/Users")]
    public class UserController : Controller
    {
        [HttpGet()]
        public IActionResult GetUser()
        {

            return Ok( UsersData.current.Users);
        }

        [HttpGet("{username}/{password}")]
        public IActionResult ValidateUser(string username,string password)
        {

            var user = UsersData.current.Users.FirstOrDefault(c => c.Username == username & c.Password==password);
                if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
            
        }
        
    }
}
