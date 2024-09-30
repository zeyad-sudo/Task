using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.Helpers.JWT
{
    public class JwtHelper
    {
        public string Key { get; set; }
        public string ValidIssuer { get; set; }
        public string[] ValidAudience { get; set; }
        public Double DurationInDays { get; set; }
    }
}
