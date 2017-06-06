using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using DataAccessLayer.Service;
using Microsoft.AspNetCore.Cors;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_API.Controllers
{
    [EnableCors("AllOrigin")]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private IATM_Repository repo;
        private ILogger logger;

        public UserController(IATM_Repository _repo, ILogger <UserController> _logger)
        {
            repo = _repo;
            logger = _logger;
        }
        
        [HttpGet("{username}/{password}")]
        public IActionResult ValidateUser(string username,string password)
        {

            try
            {
                if (!repo.UserExist(username, password))
                {
                    logger.LogInformation($"Attemp to Log In for user:{username} with password :{password}");
                    return BadRequest("Wrong username or password , please try again.");
                }
                else
                {
                    var user = repo.GetDataUser(username, password);
                    logger.LogInformation($"Log In for user:{username} with password :{password}");
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Validate User method error:_{ex.Message}_");
                return BadRequest("Error");
            }
            
        
           
            
        }
        
    }
}
