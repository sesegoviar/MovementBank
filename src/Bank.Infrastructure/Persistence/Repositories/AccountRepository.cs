using AutoMapper;
using Bank.ApplicationCore.DTOs.Account;
using Bank.ApplicationCore.Entities;
using Bank.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationCore.Exceptions;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;

        public AccountRepository(StoreContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }

        public SingleAccountResponse CreateAccount(CreateAccountRequest request)
        {
            var client = this.storeContext.Client.Find(request.ClientId);
            var account = this.mapper.Map<Account>(request);
            account.NumberAccount = request.NumberAccount;
            account.State = request.State;
            account.TypeAccount = request.TypeAccount;
            account.BalanceInitial = request.BalanceInitial;
            account.Client = client;
            this.storeContext.Account.Add(account);
            this.storeContext.SaveChanges();

            return this.mapper.Map<SingleAccountResponse>(account);
        }

        public void DeleteAccountById(int accountId)
        {
            var account = this.storeContext.Account.Find(accountId);
            if (account != null)
            {
                this.storeContext.Account.Remove(account);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public SingleAccountResponse GetAccountById(int accountId)
        {
            var accountL = this.storeContext.Account.Where(p => p.Id == accountId).Include(x => x.Client).ToList();
            if (accountL.Count>0)
            {
                var account = accountL.ElementAt(0);
                var acc = new SingleAccountResponse()
                {
                    Id = account.Id,
                    BalanceInitial = account.BalanceInitial,
                    ClientId = account.Client.Id,
                    NumberAccount = account.NumberAccount,
                    State = account.State,
                    TypeAccount = account.TypeAccount
                };
                return acc;
            }

            throw new NotFoundException();
        }

        public List<AccountResponse> GetAccounts()
        {
       
            return this.storeContext.Account.Include(x => x.Client).Select(p => this.mapper.Map<AccountResponse>(p)).ToList();
        }

        public SingleAccountResponse UpdateAccount(int accountId, UpdateAccountRequest request)
        {
            var client = this.storeContext.Client.Find(request.ClientId);
            var account = this.storeContext.Account.Find(accountId);
            if (account != null)
            {
                account.NumberAccount = request.NumberAccount;
                account.State = request.State;
                account.TypeAccount = request.TypeAccount;
                account.BalanceInitial = request.BalanceInitial;
                account.Client = client;
                this.storeContext.Account.Update(account);
                this.storeContext.SaveChanges();

                return this.mapper.Map<SingleAccountResponse>(account);
            }

            throw new NotFoundException();
        }
    }
}
