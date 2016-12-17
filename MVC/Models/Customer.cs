using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Display(Name = "אימייל")]
        [Required(ErrorMessage = "שדה חובה")]
        [EmailAddress(ErrorMessage = "הכתובת אינה כתובה אימייל תקינה")]
        public string Email { get; set; }

        [Display(Name = "שם פרטי")]
        [Required(ErrorMessage = "שדה חובה")]
        public string FirstName { get; set; }

        [Display(Name = "שם משפחה")]
        [Required(ErrorMessage = "שדה חובה")]
        public string LastName { get; set; }

        [Display(Name = "סיסמה")]
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(100, ErrorMessage = "הסיסמה צריכה להכיל מינימום 6 תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "מספר כרטיס אשראי")]
        [Required(ErrorMessage = "שדה חובה")]
        [DataType(DataType.CreditCard)]
        public string CreditCradNo { get; set; }

        [Display(Name = "גיל")]
        [Required(ErrorMessage = "שדה חובה")]
        [Range(0, 120, ErrorMessage = "גיל בטווח 0-120 בלבד")]
        public int Age { get; set; }

        [Display(Name = "עיר")]
        public string City { get; set; }

        [Display(Name = "רחוב")]
        public string Street { get; set; }

        [Display(Name = "מספר בית")]
        public string HouseNo { get; set; }

        [Display(Name = "מספר טלפון")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}