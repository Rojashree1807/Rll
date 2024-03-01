using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.Domain_Classes
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please Enter Text Only")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contains a Uppercase,Lowercase letter,number and symbol")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please Enter Ten Numbers Only")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select available or not")]
        public bool IsAvailable { get; set; }
        [Required(ErrorMessage = "Please Enter Specialization")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Please Select Timings")]
        public string Timings { get; set; }
    }
}
