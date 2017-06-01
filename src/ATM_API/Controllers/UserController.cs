using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using DataAccessLayer.Service;
using Microsoft.AspNetCore.Cors;
using System.Net;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{
    [EnableCors("AllOrigin")]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private IATM_Repository repo ;

        public UserController(IATM_Repository _repo)
        {
            repo = _repo;
        }
        
        [HttpGet("{username}/{password}")]
        public IActionResult ValidateUser(string username,string password)
        {

            try
            {
                if (!repo.UserExist(username, password))
                {
                    return BadRequest("Wrong username or password , please try again.");
                }
                else
                {
                    var user = repo.GetDataUser(username, password);
                    return Ok(user);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            
        
           
            
        }
        
    }
}
