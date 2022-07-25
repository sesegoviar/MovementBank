using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.ApplicationCore.Entities
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        public string NumberAccount { get; set; }
        public string TypeAccount { get; set; }
        public double BalanceInitial { get; set; }
        public bool State { get; set; }

        public Client Client { get; set; }
    }
}
