using Models.Entities;
using Infrastructure.Business.Abstract;
using Infrastructure.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IBusinessBase<User>
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        User UsernameOrPhoneNumberLogin(string Username, string PhoneNumber, string email);
        public bool PasswordAttempt(string Username, string PhoneNumber, string email);
    }
}
