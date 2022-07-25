using Bank.ApplicationCore.DTOs.Client;
using Bank.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <response code="200">Returns the clients</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClientResponse>))]
        public ActionResult GetClients()
        {
            return Ok(this.clientRepository.GetClients());
        }

        /// <summary>
        /// Get a client by id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <response code="200">Returns the existing client</response>
        /// <response code="404">If the client doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleClientResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetClientById(int id)
        {
            try
            {
                var client = this.clientRepository.GetClientById(id);
                return Ok(client);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a client
        /// </summary>
        /// <param name="request">Client data</param>
        /// <response code="201">Returns the created client</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SingleClientResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CreateClientRequest request)
        {
            var client = this.clientRepository.CreateClient(request);
            return StatusCode(201, client);
        }

        /// <summary>
        /// Update a client by id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="request">Client data</param>
        /// <response code="200">Returns the updated client</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        /// <response code="404">If the client doesn't exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleClientResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, UpdateClientRequest request)
        {
            try
            {
                var client = this.clientRepository.UpdateClient(id, request);
                return Ok(client);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a client by id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <response code="204">If the client was deleted</response>
        /// <response code="404">If the client doesn't exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                this.clientRepository.DeleteClientById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
