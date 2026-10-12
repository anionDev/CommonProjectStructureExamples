using DotNetWebAPICodeUnit.Core.Constants;
using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Core.Controller
{
    /// <summary>
    /// Example-controller which shows how a controller is built: it translates between http and the business-logic
    /// and contains no rules of its own. The rules are in the business-logic-service and the storing is in the persistence.
    /// </summary>
    [ApiController]
    [Route(CustomerController.ControllerRoute)]
    public class CustomerController : ControllerBase
    {
        public const string ControllerRoute = $"{ServerConfiguration.APIRoutePrefix}/v{GeneralConstants.CodeUnitMajorVersion}/{nameof(CustomerController)}";
        private readonly IGeneralLogger _Logger;
        private readonly IBusinessLogicService _BusinessLogicService;

        public CustomerController(IServerLog logger, IBusinessLogicService businessLogicService)
        {
            this._Logger = logger.Logger;
            this._BusinessLogicService = businessLogicService;
        }

        /// <summary>Returns all customers.</summary>
        /// <returns>200 OK with all customers.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer[]))]
        [Route(nameof(GetAllCustomers))]
        public IActionResult GetAllCustomers()
        {
            return this.Ok(this._BusinessLogicService.GetAllCustomers().ToArray());
        }

        /// <summary>Returns the customer with the given id.</summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <returns>200 OK with the customer.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [Route($"{nameof(GetCustomer)}/{{{nameof(customerId)}}}")]
        public IActionResult GetCustomer([FromRoute] int customerId)
        {
            return this.Ok(this._BusinessLogicService.GetCustomer(customerId));
        }

        /// <summary>Creates a new customer.</summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="contactEmailAddress">The email-address under which the customer is contacted.</param>
        /// <returns>200 OK with the id which the new customer got.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [Route(nameof(CreateCustomer))]
        public IActionResult CreateCustomer([FromQuery] string name, [FromQuery] string contactEmailAddress)
        {
            return this.Ok(this._BusinessLogicService.CreateCustomer(name, contactEmailAddress));
        }

        /// <summary>Applies the given values to the customer which has the given id.</summary>
        /// <param name="customer">The customer with the new values.</param>
        /// <returns>200 OK if the customer was updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route(nameof(UpdateCustomer))]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            this._BusinessLogicService.UpdateCustomer(customer);
            return this.Ok();
        }

        /// <summary>Removes the customer with the given id.</summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <returns>200 OK if the customer was removed.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route($"{nameof(RemoveCustomer)}/{{{nameof(customerId)}}}")]
        public IActionResult RemoveCustomer([FromRoute] int customerId)
        {
            this._BusinessLogicService.RemoveCustomer(customerId);
            return this.Ok();
        }
    }
}
