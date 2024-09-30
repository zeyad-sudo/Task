using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.CarDto
{
    public class AddCarDto
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturerYear { get; set; }
        public string Brand { get; set; }
    }
}
