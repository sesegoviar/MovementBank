using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.ApplicationCore.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Genre { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Direction { get; set; }
        public string Phono { get; set; }
    }
}
