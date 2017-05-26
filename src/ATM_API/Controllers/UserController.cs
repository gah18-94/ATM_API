using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using ATM_API.Models;
using DataAccessLayer.Models;
using DataAccessLayer;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{
    [Route("api/Users")]
    public class UserController : Controller
    {
        private IATM_Repository repo ;
        private ATM_context context;

        public UserController(IATM_Repository _repo, ATM_context _context)
        {
            repo = _repo;
            context = _context;
        }

        [HttpGet()]
        public IActionResult GetUser()
        {

            return Ok( UsersData.current.Users);
        }

        [HttpGet("{username}/{password}")]
        public IActionResult ValidateUser(string username,string password)
        {
            
            var user = repo.ValidateUser(username,password);
 
            return Ok( user);
            
        }
        
    }
}
