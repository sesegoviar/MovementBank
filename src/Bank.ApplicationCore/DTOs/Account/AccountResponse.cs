using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.DTOs.Account
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string NumberAccount { get; set; }
        public string TypeAccount { get; set; }
        public double BalanceInitial { get; set; }
        public bool State { get; set; }
        public int ClientId { get; set; }
    }
}
