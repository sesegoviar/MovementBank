using Bank.ApplicationCore.DTOs.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Client
{
    public class CreateClientRequest : CreatePersonRequest
    {
        [Required]
        public string ClientUser { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool State { get; set; }
    }
}
