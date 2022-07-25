using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Movement
{
    public class MovementResponse
    {
        public int Id { get; set; }

        public string Balance { get; set; }
        public double Value { get; set; }
        public string TypeMovement { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
    }
}
