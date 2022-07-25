using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Person
{
    public class PersonResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Genre { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Direction { get; set; }
        public string Phono { get; set; }
    }
}
