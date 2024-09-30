using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.CarDto
{
    public class CarDto
    {
        public int PlateNumber { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public DateOnly ManufacturerYear { get; set; }
        public string Brand { get; set; }
        public string ApplicationUserDto { get; set; }
    }
}
