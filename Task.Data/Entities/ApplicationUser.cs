using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string IdentityNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
