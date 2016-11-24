using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Branch
    {
        public int BranchID { get; set; }

        [Display(Name = "שם חנות")]
        [Required(ErrorMessage = "שדה חובה")]
        public string Name { get; set; }

        [Display(Name = "עיר")]
        [Required(ErrorMessage = "שדה חובה")]
        public string City { get; set; }

        [Display(Name = "רחוב")]
        [Required(ErrorMessage = "שדה חובה")]
        public string Street { get; set; }

        [Display(Name = "מספר בית")]
        [Required(ErrorMessage = "שדה חובה")]
        public int HouseNo { get; set; }

        [Display(Name = "נקודת אורך")]
        [Required(ErrorMessage = "שדה חובה")]
        public double CoorX { get; set; }

        [Display(Name = "נקודת רוחב")]
        [Required(ErrorMessage = "שדה חובה")]
        public double CoorY { get; set; }
        
        [Display(Name = "מספר טלפון")]
        public string PhoneNo { get; set; }
        
    }
}