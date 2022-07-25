using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Movement
{
    public class CreateMovementRequest
    {
       // [Required]
        //public string Balance { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public string TypeMovement { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AccountId { get; set; }
    }
}
