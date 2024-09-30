using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Data.Entities
{
    public class UserCar
    {
        public int Id { get; set; }
        public string ApplicationUserID { get; set; }
        public int CarPlateNumber { get; set; }
        public DateTime AssignDate { get; set; }
        public int LastMeterReading { get; set; }
        public Car car { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
