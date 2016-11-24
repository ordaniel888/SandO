using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public enum e_Size
    {
        XS,S,M,L
    }

    public enum e_Category
    {
        SHIRTS,
        PANTS,
        DRESSES,
        ACCESSORIES,
    }

    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "שם מוצר")]
        [Required(ErrorMessage = "שדה חובה")]
        public string Name { get; set; }

        [Display(Name = "קטגוריה")]
        [Required(ErrorMessage = "שדה חובה")]
        public e_Category Category { get; set; }

        [Display(Name = "מידה")]
        [Required(ErrorMessage = "שדה חובה")]
        public e_Size Size { get; set; }

        [Display(Name = "תמונת מוצר")]
        [Required(ErrorMessage = "שדה חובה")]
        public string Image { get; set; }

        [Display(Name = "מחיר")]
        [Required(ErrorMessage = "שדה חובה")]
        public int Price { get; set; }

        [Display(Name = "תיאור מוצר")]
        public string Description { get; set; }

        [Display(Name = "האם בהנחה?")]
        public bool IsOnSale { get; set; }

        [Display(Name = "מיקום")]
        [Required(ErrorMessage = "שדה חובה")]
        public int BranchID { get; set; }

        public virtual Branch Branch { get; set; }
    }
}