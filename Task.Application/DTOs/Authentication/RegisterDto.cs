using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.Authentication
{
    public class RegisterDto
    {
        [Required, StringLength(14)]
        public string IdentityNumber { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
