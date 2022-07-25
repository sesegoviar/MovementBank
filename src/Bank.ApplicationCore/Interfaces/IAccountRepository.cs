using Bank.ApplicationCore.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.Interfaces
{
    public interface IAccountRepository
    {
        List<AccountResponse> GetAccounts();

        SingleAccountResponse GetAccountById(int accountId);

        void DeleteAccountById(int accountId);

        SingleAccountResponse CreateAccount(CreateAccountRequest request);

        SingleAccountResponse UpdateAccount(int accountId, UpdateAccountRequest request);
    }
}
