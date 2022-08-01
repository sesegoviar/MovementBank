using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Bank.ApplicationCore.DTOs.Account;
using Bank.ApplicationCore.DTOs.Movement;
using Bank.ApplicationCore.Entities;
using Bank.ApplicationCore.Interfaces;
using Store.ApplicationCore.Exceptions;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.ApplicationCore.Common.Constants;

namespace Bank.Infrastructure.Persistence.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;

        public MovementRepository(StoreContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }

        public SingleMovementResponse CreateMovement(CreateMovementRequest request)
        {
            var obj = this.storeContext.Movement.Find(request.AccountId);
            var account = this.storeContext.Account.Find(request.AccountId);
            var movementBalance = this.storeContext.Movement.Select(p => this.mapper.Map<MovementResponse>(p)).ToList().Where(x => x.AccountId==request.AccountId);
            var movement = this.mapper.Map<Movement>(request);
            var balance = 0.0;
            if (movementBalance.Count()> 0)
            {
                if (request.TypeMovement.Equals(Constant.AHORRO))
                    balance = Convert.ToDouble(movementBalance.FirstOrDefault().Balance) + request.Value;
                else
                    balance = Convert.ToDouble(movementBalance.FirstOrDefault().Balance) - request.Value;
            }
            else
            {
                if(request.TypeMovement.Equals(Constant.AHORRO))
                    balance = account.BalanceInitial + request.Value;
                else
                    balance = account.BalanceInitial - request.Value;
            }
            movement.Balance = balance.ToString();
            movement.Value = request.Value;
            movement.Date = request.Date;
            movement.TypeMovement = request.TypeMovement;
            movement.Account = account;
            this.storeContext.Movement.Add(movement);
            this.storeContext.SaveChanges();

            return this.mapper.Map<SingleMovementResponse>(movement);
        }

        public void DeleteMovementById(int movementId)
        {
            var movement = this.storeContext.Movement.Find(movementId);
            if (movement != null)
            {
                this.storeContext.Movement.Remove(movement);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public SingleMovementResponse GetMovementById(int movementId)
        {
            var movementL = this.storeContext.Movement.Where(p => p.Id == movementId).Include(x => x.Account).ToList();
            if (movementL.Count>0)
            {
                var movement = movementL.ElementAt(0);
                var mov = new SingleMovementResponse()
                {
                    Id = movement.Id,
                    Balance = movement.Balance,
                    Date = movement.Date,
                    AccountId = movement.Account.Id,
                    TypeMovement = movement.TypeMovement,
                    Value = movement.Value
                };
                return mov;
            }

            throw new NotFoundException();
        }

        public List<MovementResponse> GetMovements()
        {
            return this.storeContext.Movement.Include(x => x.Account).Select(p => this.mapper.Map<MovementResponse>(p)).ToList();


        }

        public SingleMovementResponse UpdateMovement(int movementId, UpdateMovementRequest request)
        {
            var account = this.storeContext.Account.Find(request.AccountId);
            var movement = this.storeContext.Movement.Find(movementId);
            if (movement != null)
            {
                movement.Value = request.Value;
                movement.Date = request.Date;
                movement.TypeMovement = request.TypeMovement;
                movement.Account = account;
                this.storeContext.Movement.Update(movement);
                this.storeContext.SaveChanges();

                return this.mapper.Map<SingleMovementResponse>(movement);
            }

            throw new NotFoundException();
        }
        public List<ReporteResponse> GetMovements(DateTime date, int client)
        {

            var accounts = this.storeContext.Account.Where(p => p.Client.Id==client).Include(x=>x.Client).ToList();
            List<MovementResponse> lista = new List<MovementResponse>();
            List<ReporteResponse> reporte = new List<ReporteResponse>();
            foreach (var account in accounts)
            {
                var movement = this.storeContext.Movement.Select(p => this.mapper.Map<MovementResponse>(p)).ToList().Where(x => x.AccountId == account.Id && x.Date>= date && x.Date< date.AddDays(+1)).ToList();
                lista.AddRange(movement);
            }
            foreach (var list in lista)
            {
                var account = this.storeContext.Account.Find(list.AccountId);
                var reporteI = new ReporteResponse()
                {

                    Date = list.Date,
                    Client = account.Client.Name,
                    NumberAccount = account.NumberAccount,
                    TypeAccount = account.TypeAccount,
                    SaldoInicial = account.BalanceInitial,
                    State = account.State.ToString(),
                    Movimiento = list.Value,
                    SaldoDisponible = Convert.ToDouble(list.Balance)

                };
                reporte.Add(reporteI);
            }
            return reporte;
        }
    }
}
