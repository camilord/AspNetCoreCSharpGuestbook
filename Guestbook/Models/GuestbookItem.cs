using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Guestbook.Models
{
    public class GuestbookItem
    {
        public long Id { get; set; }

        [Display(Name = "Guest Name")]
        [StringLength(128, MinimumLength = 2, ErrorMessage = "Please enter your name.")]
        [Required]
        public string GuestName { get; set; }

        [StringLength(250, MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }

        [MinLength(10, ErrorMessage = "Please enter your message properly.")]
        [Required]
        public String Message { get; set; }

        [StringLength(128)]
        public String IPAddress { get; set; }

        //[StringLength(200)]
        //public String AgentInfo { get; set; }

        [BindProperty(Name = "g-recaptcha-response")]
        [Required]
        public String Recaptcha { get; set; }

        public DateTime Created { get; set; }
    }
}
