using DotNetWebAPICodeUnit.Core.Constants;
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
        public const string ControllerRoute = $"{ServerConfiguration.APIRoutePrefix}/v{GeneralConstants.CodeUnitMajorVersion}/{nameof(ExampleController)}";
        private readonly IMathService _MathService;
        private readonly IGeneralLogger _Logger;
        private readonly IPersistence _Persistence;
        public ExampleController(IMathService someService, IGeneralLogger logger, IPersistence persistence)
        {
            this._MathService = someService;
            this._Logger = logger;
            this._Persistence = persistence;
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
        [Route($"Calculator/{{{nameof(function)}}}")]
        public IActionResult Calculate([FromRoute] string function, [FromQuery] decimal parameter1, [FromQuery] decimal parameter2)
        {
            return function switch
            {
                nameof(IMathService.Add) => this.Ok(this._MathService.Add(parameter1, parameter2)),
                nameof(IMathService.Sub) => this.Ok(this._MathService.Sub(parameter1, parameter2)),
                nameof(IMathService.Mul) => this.Ok(this._MathService.Mul(parameter1, parameter2)),
                nameof(IMathService.Div) => this.Ok(this._MathService.Div(parameter1, parameter2)),
                _ => this.BadRequest($"Unknown function: \"{function}\""),
            };
        }
    }
}
