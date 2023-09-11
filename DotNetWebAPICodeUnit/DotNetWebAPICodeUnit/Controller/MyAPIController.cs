using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetWebAPICodeUnit.Core.Controller
{
    [ApiController]
    [Route(MyAPIController.ControllerRoute)]
    public class MyAPIController : ControllerBase
    {
        public const string ControllerRoute = $"/{ServerConfiguration.APIRoutePrefix}/{nameof(MyAPIController)}";
        private readonly ISomeService _SomeService;
        private readonly IGeneralLogger _Logger;
        public MyAPIController(ISomeService someService, IGeneralLogger logger)
        {
            this._SomeService = someService;
            this._Logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [Route($"{nameof(SomeFunction)}/{{parameter1}}")]
        public IActionResult SomeFunction([FromRoute] string parameter1, [FromQuery] int parameter2, [FromQuery] int parameter3)
        {
            this._Logger.Log($"{nameof(SomeFunction)} will be executed with parameter \"{parameter1}\".", LogLevel.Information);
            return this.Ok(DotNetLibraryCodeUnit.Core.Utilities.Add((ulong)parameter2, (ulong)parameter3));
        }
    }
}
