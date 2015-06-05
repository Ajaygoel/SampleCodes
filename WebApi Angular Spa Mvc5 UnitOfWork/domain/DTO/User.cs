using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace domain.Model
{
    public class User
    {
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

    }
}