using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Request
{
    public class MusicRequest
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
