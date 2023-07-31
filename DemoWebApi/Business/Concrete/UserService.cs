using Business.Abstract;
using DataAccess.Abstract;
using Models.Entities;
using Infrastructure.Business.Concrete;
using Infrastructure.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : BusinessBase<User>, IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _repo.GetClaims(user);
        }

        public void Add(User user)
        {
            _repo.Add(user);
        }

        public User GetByMail(string email)
        {
            return _repo.Get(u => u.Email == email).Data;
        }

        public User UsernameOrPhoneNumberLogin(string Username, string PhoneNumber, string email)
        {
            var u = _repo.Get(u => u.UserName == Username || u.PhoneNumber == PhoneNumber || u.Email == email).Data;
            if (u.FailedLoginAttempts == 5)
            {
                if (u.LockoutEndTime < DateTime.Now)
                {
                    u.LockoutEndTime = null;
                    u.FailedLoginAttempts = 0;
                    _repo.Update(u);
                }
            }
            return u;


        }

        public bool PasswordAttempt(string Username, string PhoneNumber, string email)
        {
            var u = _repo.Get(u => u.UserName == Username || u.PhoneNumber == PhoneNumber || u.Email == email).Data;
            if (u.FailedLoginAttempts < 5)
            {
                u.FailedLoginAttempts = u.FailedLoginAttempts + 1;
                _repo.Update(u);
                return true;
            }
            else
            {
                u.LockoutEndTime = DateTime.Now.AddMinutes(10);
                _repo.Update(u);
                return false;
            }

        }
    }
}
