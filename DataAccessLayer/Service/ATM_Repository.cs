using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_API.Models;

namespace DataAccessLayer.Service
{
    public class ATM_Repository : IATM_Repository
    {
        private ATM_context _context;

        public ATM_Repository(ATM_context context)
        {
            _context = context;
        }
        public UserModel ValidateUser(string username, string password)
        {
           
            return _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        
        }

        public bool UserExist( string username, string password) {
            if (!_context.Users.Any(u => u.Username == username))
            {
                return false;
            }
            else
            {
                if(_context.Users.Any(u => u.Username == username && u.Password == password))
                {
                    return true;
                }
                return false;
            }
        }



    }
}
