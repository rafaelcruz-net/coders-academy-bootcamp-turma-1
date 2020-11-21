using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Request
{
    public class RegisterRequest
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
