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
    [Route("api/Users/{username}/{password}")]
    public class TransactionHistory : Controller
    {
        private IATM_Repository repo;

        public TransactionHistory(IATM_Repository _repo)
        {
            repo = _repo;
        }

        [HttpGet("/TransactionHistory/{Id_Account}/{StartDate}/{EndDate}")]
        public IActionResult GetTransactionHistory(string username, string password, string Id_Account,DateTime StartDate, DateTime EndDate)
        {

            try
            {
                if (!repo.UserExist(username, password))
                {
                    return Ok(false);
                }
                else
                {
                    var account = repo.GetTransactionHistory(Int16.Parse(Id_Account), StartDate, EndDate);
                    return Ok(account);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        
    }
}
