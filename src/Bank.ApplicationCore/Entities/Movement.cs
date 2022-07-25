using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.ApplicationCore.Entities
{
    public class Movement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Balance { get; set; }
        public double Value { get; set; }
        public string TypeMovement { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}
