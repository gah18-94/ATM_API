using ATM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public interface IATM_Repository
    {
        UserModel ValidateUser(string username, string password);
        bool UserExist(string username, string password);

    }
}
