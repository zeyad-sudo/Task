using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.UserCarDto
{
    public class AssignCarToUserDto
    {
        [Required]
        public string ApplicationUserId { get; set;}
        [Required]
        public int CarBlateNumber { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime AssignedDate { get; set; }
        [Required]
        public int LastMeterReading { get; set; }
    }
}
