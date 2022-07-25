using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Account
{
    public class CreateAccountRequest
    {
        [Required]
        public string NumberAccount { get; set; }
        [Required]
        public string TypeAccount { get; set; }
        [Required]
        public double BalanceInitial { get; set; }
        [Required]
        public bool State { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
