using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;

        public AuthService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public AppUser? Login(string username, string password)
        {
            return _uow.AppUsers
                .GetAll(u => u.UserName == username
                          && u.PasswordHash == password
                          && u.IsActive)
                .FirstOrDefault();
        }
    }
}