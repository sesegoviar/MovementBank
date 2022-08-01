using AutoMapper;
using Bank.ApplicationCore.DTOs.Person;
using Bank.ApplicationCore.Entities;
using Bank.ApplicationCore.Interfaces;
using Store.ApplicationCore.DTOs;
using Store.ApplicationCore.Exceptions;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;

        public PersonRepository(StoreContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }
    }
}
