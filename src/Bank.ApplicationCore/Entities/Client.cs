using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.ApplicationCore.Entities
{
    public class Client : Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(15)]
        public string ClientUser { get; set; }
        [MaxLength(15)]
        public string Password { get; set; }
        public bool State { get; set; }
    }
}
