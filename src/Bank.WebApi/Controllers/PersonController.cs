using Bank.ApplicationCore.DTOs.Person;
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
    public class PersonController: Controller
    {
        /*private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <response code="200">Returns the persons</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonResponse>))]
        public ActionResult GetPersons()
        {
            return Ok(this.personRepository.GetPersons());
        }

        /// <summary>
        /// Get a person by id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <response code="200">Returns the existing person</response>
        /// <response code="404">If the person doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SinglePersonResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetPersonById(int id)
        {
            try
            {
                var person = this.personRepository.GetPersonById(id);
                return Ok(person);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a person
        /// </summary>
        /// <param name="request">Person data</param>
        /// <response code="201">Returns the created person</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SinglePersonResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CreatePersonRequest request)
        {
            var person = this.personRepository.CreatePerson(request);
            return StatusCode(201, person);
        }

        /// <summary>
        /// Update a person by id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <param name="request">Person data</param>
        /// <response code="200">Returns the updated person</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        /// <response code="404">If the person doesn't exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SinglePersonResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, UpdatePersonRequest request)
        {
            try
            {
                var person = this.personRepository.UpdatePerson(id, request);
                return Ok(person);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a person by id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <response code="204">If the person was deleted</response>
        /// <response code="404">If the person doesn't exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                this.personRepository.DeletePersonById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }*/
    }
}
