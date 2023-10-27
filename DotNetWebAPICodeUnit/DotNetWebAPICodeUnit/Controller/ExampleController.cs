using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetWebAPICodeUnit.Core.Controller
{
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [Route($"{nameof(Add)}/{{parameter1}}")]
        public IActionResult Add([FromRoute] string parameter1, [FromQuery] int parameter2, [FromQuery] int parameter3)
        {
            this._Logger.Log($"{nameof(Add)} will be executed with parameter \"{parameter1}\".", LogLevel.Information);
            return this.Ok(DotNetLibraryCodeUnit.Core.Utilities.Add((ulong)parameter2, (ulong)parameter3));
        }
    }
}
