using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.Authentication
{
    public class TokenRequestDto
    {
        [Required, StringLength(100)]
        public string IdentityNumber { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
