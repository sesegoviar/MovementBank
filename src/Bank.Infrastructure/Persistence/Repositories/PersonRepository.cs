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

        /*public SinglePersonResponse CreatePerson(CreatePersonRequest request)
        {
            var person = this.mapper.Map<Person>(request);
            person.Name = request.Name;
            person.Identification = request.Identification;
            person.Phono = request.Phono;
            person.Genre = request.Genre;
            person.Direction = request.Direction;
            person.Age = request.Age;

            this.storeContext.Person.Add(person);
            this.storeContext.SaveChanges();

            return this.mapper.Map<SinglePersonResponse>(person);
        }

        public void DeletePersonById(int personId)
        {
            var person = this.storeContext.Person.Find(personId);
            if (person != null)
            {
                this.storeContext.Person.Remove(person);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public SinglePersonResponse GetPersonById(int personId)
        {
            var person = this.storeContext.Person.Find(personId);
            if (person != null)
            {
                return this.mapper.Map<SinglePersonResponse>(person);
            }

            throw new NotFoundException();
        }

        public List<PersonResponse> GetPersons()
        {
            return this.storeContext.Person.Select(p => this.mapper.Map<PersonResponse>(p)).ToList();
        }

        public SinglePersonResponse UpdatePerson(int personId, UpdatePersonRequest request)
        {
            var person = this.storeContext.Person.Find(personId);
            if (person != null)
            {
                person.Name = request.Name;
                person.Identification = request.Identification;
                person.Age = request.Age;
                person.Genre = request.Genre;
                person.Direction = request.Direction;
                person.Phono = request.Phono;

                this.storeContext.Person.Update(person);
                this.storeContext.SaveChanges();

                return this.mapper.Map<SinglePersonResponse>(person);
            }

            throw new NotFoundException();
        }*/
    }
}
