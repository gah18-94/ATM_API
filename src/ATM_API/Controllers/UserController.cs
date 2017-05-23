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

        [HttpGet("{username}")]
        public IActionResult ValidateUser(string username)
        {

            var user = UsersData.current.Users.FirstOrDefault(c => c.Username == username);
                if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
            
        }

       /* [HttpGet("{id}")]
        public IActionResult Login(string username, string pwd)
        {
            var user = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (user == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(cityWithoutPointsOfInterestResult);
        }*/
    }
}
