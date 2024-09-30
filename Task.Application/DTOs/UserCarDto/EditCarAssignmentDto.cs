using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.DTOs.UserCarDto
{
    public class EditCarAssignmentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CarPlateNumber { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AssignedDate { get; set; }
        public int LastMeterReading { get; set; }
    }
}
