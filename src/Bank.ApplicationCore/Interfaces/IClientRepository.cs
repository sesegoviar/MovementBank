using Bank.ApplicationCore.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.Interfaces
{
    public interface IClientRepository
    {
        List<ClientResponse> GetClients();

        SingleClientResponse GetClientById(int clientId);

        void DeleteClientById(int clientId);

        SingleClientResponse CreateClient(CreateClientRequest request);

        SingleClientResponse UpdateClient(int clientId, UpdateClientRequest request);
    }
}
