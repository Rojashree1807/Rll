using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.Domain_Classes
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Required(ErrorMessage = "Please enter medicine name")]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }
        [Required(ErrorMessage = "Please Enter price")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Please Enter Manufacture Date")]
        public DateTime ManufactureDate { get; set; }
        [Required(ErrorMessage = "Please Enter Expired Date")]
        public DateTime ExpiredDate { get; set; }
        [Required(ErrorMessage = "Please Enter Discount")]
        public float Discount { get; set; }
        [Required(ErrorMessage = "Please Enter Tax")]
        public float Tax { get; set; }
        [Required(ErrorMessage = "Please select available or not")]
        public bool IsAvailable { get; set; }
    }
}
