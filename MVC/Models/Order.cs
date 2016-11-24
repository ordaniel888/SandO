using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "שדה חובה")]       
        public int ProductID { get; set; }

        [Display(Name = "תאריך רכישה")]
        public DateTime PurchaseDate { get; set; } 

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }

}