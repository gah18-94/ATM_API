using ATM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public interface IATM_Repository
    {
        UserModel ValidateUser(string username, string password);

    }
}
