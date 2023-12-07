using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPICodeUnit.Core.Controller
{
    /// <summary>
    /// Represents an example-controller.
    /// </summary>
    [ApiController]
    [Route(ExampleController.ControllerRoute)]
    public class ExampleController : ControllerBase
    {
        public const string ControllerRoute = $"/{ServerConfiguration.APIRoutePrefix}/{nameof(ExampleController)}";
        private readonly ISomeService _SomeService;
        private readonly IGeneralLogger _Logger;
        public ExampleController(ISomeService someService, IGeneralLogger logger)
        {
            this._SomeService = someService;
            this._Logger = logger;
        }

        /// <summary>
        /// Adds 2 values.
        /// </summary>
        /// <param name="parameter1">Summand 1</param>
        /// <param name="parameter2">Summand 2</param>
        /// <returns>
        /// Returns the sum of <paramref name="parameter1"/> and <paramref name="parameter2"/>.
        /// </returns>
        /// <remarks>
        /// <paramref name="parameter1"/> and <paramref name="parameter2"/> can be integer-values or decimal-values.
        /// If there are decimal-places then the decimal-places must be separated by a dot.
        /// </remarks>
        /// <example>
        /// Example-Route: /API/ExampleController/Add/2/3.5
        /// </example>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [Route($"{nameof(Add)}/{{{nameof(parameter1)}}}/{{{nameof(parameter2)}}}")]
        public IActionResult Add(decimal parameter1, decimal parameter2)
        {
            return this.Ok(this._SomeService.Add(parameter1,parameter2));
        }
    }
}
