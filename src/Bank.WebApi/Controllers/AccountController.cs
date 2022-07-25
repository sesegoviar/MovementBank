using Bank.ApplicationCore.DTOs.Account;
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
    public class AccountController: Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <response code="200">Returns the accounts</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountResponse>))]
        public ActionResult GetAccounts()
        {
            return Ok(this.accountRepository.GetAccounts());
        }

        /// <summary>
        /// Get a account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <response code="200">Returns the existing account</response>
        /// <response code="404">If the account doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleAccountResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAccountById(int id)
        {
            try
            {
                var account = this.accountRepository.GetAccountById(id);
                return Ok(account);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a account
        /// </summary>
        /// <param name="request">Account data</param>
        /// <response code="201">Returns the created account</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SingleAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(CreateAccountRequest request)
        {
            var account = this.accountRepository.CreateAccount(request);
            return StatusCode(201, account);
        }

        /// <summary>
        /// Update a account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <param name="request">Account data</param>
        /// <response code="200">Returns the updated account</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        /// <response code="404">If the account doesn't exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(int id, UpdateAccountRequest request)
        {
            try
            {
                var account = this.accountRepository.UpdateAccount(id, request);
                return Ok(account);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <response code="204">If the account was deleted</response>
        /// <response code="404">If the account doesn't exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                this.accountRepository.DeleteAccountById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
