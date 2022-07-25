using AutoMapper;
using Bank.ApplicationCore.DTOs.Client;
using Bank.ApplicationCore.Entities;
using Bank.ApplicationCore.Interfaces;
using Store.ApplicationCore.Exceptions;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;

        public ClientRepository(StoreContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }

        public SingleClientResponse CreateClient(CreateClientRequest request)
        {
            var client = this.mapper.Map<Client>(request);
            client.Identification = request.Identification;
            client.Name = request.Name;
            client.Age = request.Age;
            client.Genre = request.Genre;
            client.Direction = request.Direction;
            client.Phono = request.Phono;
            client.ClientUser = request.ClientUser;
            client.Password = request.Password;
            client.State = request.State;
 
            this.storeContext.Client.Add(client);
            this.storeContext.SaveChanges();

            return this.mapper.Map<SingleClientResponse>(client);
        }

        public void DeleteClientById(int clientId)
        {
            var client = this.storeContext.Client.Find(clientId);
            if (client != null)
            {
                this.storeContext.Client.Remove(client);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public SingleClientResponse GetClientById(int clientId)
        {
            var client = this.storeContext.Client.Find(clientId);
            if (client != null)
            {
                return this.mapper.Map<SingleClientResponse>(client);
            }

            throw new NotFoundException();
        }

        public List<ClientResponse> GetClients()
        {
            return this.storeContext.Client.Select(p => this.mapper.Map<ClientResponse>(p)).ToList();
        }

        public SingleClientResponse UpdateClient(int clientId, UpdateClientRequest request)
        {
            var client = this.storeContext.Client.Find(clientId);
            if (client != null)
            {
                client.Identification = request.Identification;
                client.Name = request.Name;
                client.Age = request.Age;
                client.Genre = request.Genre;
                client.Direction = request.Direction;
                client.Phono = request.Phono;
                client.ClientUser = request.ClientUser;
                client.Password = request.Password;
                client.State = request.State;
                
                this.storeContext.Client.Update(client);
                this.storeContext.SaveChanges();

                return this.mapper.Map<SingleClientResponse>(client);
            }

            throw new NotFoundException();
        }
    }
}
