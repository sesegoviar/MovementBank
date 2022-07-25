using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Client
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string ClientUser { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
    }
}
