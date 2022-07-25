using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Person
{
    public class CreatePersonRequest
    {
        [Required]
        public string Name { get; set; }

        public string Genre { get; set; }
        public int Age { get; set; }
        [Required]
        public string Identification { get; set; }
        [Required]
        public string Direction { get; set; }
        [Required]
        public string Phono { get; set; }
    }
}
