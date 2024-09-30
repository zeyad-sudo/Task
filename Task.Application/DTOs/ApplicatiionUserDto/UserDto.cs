using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.ApplicatiionUserDto
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required]
        public string IdentitNumber { get; set; }
        public string phoneNumber { get; set; }
    }
}
