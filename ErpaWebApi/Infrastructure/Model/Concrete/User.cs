using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Concrete
{
    public class User : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IdentificationNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockoutEndTime { get; set; }
    }
}
