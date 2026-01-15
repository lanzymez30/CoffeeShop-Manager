using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Interfaces
{
    public interface IAuthService
    {
        AppUser? Login(string username, string password);
    }
}
