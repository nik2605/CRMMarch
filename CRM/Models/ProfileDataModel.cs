using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ProfileDataModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter firstname")]
        [Display(Name = "Please enter First Name")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please enter lastname")]
        [Display(Name = "Please enter Last Name")]
        public string LName { get; set; }

        public string Name => $"{FName} {LName}";

    }


    
}