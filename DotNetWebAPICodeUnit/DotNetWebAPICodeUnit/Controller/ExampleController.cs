using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [Route($"{nameof(Add)}/{{{nameof(parameter1)}}}/{{{nameof(parameter2)}}}")]
        public IActionResult Add(decimal parameter1, decimal parameter2)
        {
            return this.Ok(DotNetLibraryCodeUnit.Core.Utilities.Add(parameter1, parameter2));
        }
    }
}
