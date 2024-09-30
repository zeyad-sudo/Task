using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.CarDto
{
    public class UpdateCarDto
    {
        [Required]
        public int PlateNumber { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public DateOnly ManufacturerYear { get; set; }
        public string Brand { get; set; }
        public string ApplicationUserDto { get; set; }
    }
}
