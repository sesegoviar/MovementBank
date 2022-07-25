using Bank.ApplicationCore.DTOs.Movement;
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
    public class MovementController : Controller
    {
        private readonly IMovementRepository movementRepository;

        public MovementController(IMovementRepository movementRepository)
        {
            this.movementRepository = movementRepository;
        }

        /// <summary>
        /// Get all movements
        /// </summary>
        /// <response code="200">Returns the movements</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MovementResponse>))]
        public ActionResult GetMovements()
        {
            return Ok(this.movementRepository.GetMovements());
        }

        /// <summary>
        /// Get a movement by id
        /// </summary>
        /// <param name="id">Movement id</param>
        /// <response code="200">Returns the existing movement</response>
        /// <response code="404">If the movement doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleMovementResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetMovementById(int id)
        {
            try
            {
                var movement = this.movementRepository.GetMovementById(id);
                return Ok(movement);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a movement
        /// </summary>
        /// <param name="request">Movement data</param>
        /// <response code="201">Returns the created movement</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SingleMovementResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CreateMovementRequest request)
        {
            var movement = this.movementRepository.CreateMovement(request);
            return StatusCode(201, movement);
        }

        /// <summary>
        /// Update a movement by id
        /// </summary>
        /// <param name="id">Movement id</param>
        /// <param name="request">Movement data</param>
        /// <response code="200">Returns the updated movement</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        /// <response code="404">If the movement doesn't exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleMovementResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, UpdateMovementRequest request)
        {
            try
            {
                var movement = this.movementRepository.UpdateMovement(id, request);
                return Ok(movement);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a movement by id
        /// </summary>
        /// <param name="id">Movement id</param>
        /// <response code="204">If the movement was deleted</response>
        /// <response code="404">If the movement doesn't exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                this.movementRepository.DeleteMovementById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get all movements for user and date
        /// </summary>
        /// <response code="200">Returns the movements</response>
        [HttpGet("Report")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReporteResponse>))]
        public ActionResult GetMovements(DateTime date, int idClient)
        {
            return Ok(this.movementRepository.GetMovements(date, idClient));
        }
    }
}
