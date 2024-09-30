using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.Authentication
{
    public class AuthDto
    {
        
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Token { get; set; }
    }
}
