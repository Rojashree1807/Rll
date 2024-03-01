using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.Domain_Classes
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime StartDateTime { get; set; }
        [Required]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please Select Details")]
        public string Details { get; set; }
        [Required]
        public bool IsApprove { get; set; }
        public int MsgLimit { get; set; }
        [Required(ErrorMessage = "Please Select Patient")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Please Select Doctor")]
        public int DoctorId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
