using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3Train.Web.Areas.Admin.Data
{
    public class Login
    {
        [Required(ErrorMessage = "Must not be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Must not be empty")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}