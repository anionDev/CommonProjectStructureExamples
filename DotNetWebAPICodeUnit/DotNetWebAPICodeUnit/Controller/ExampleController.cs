using DotNetWebAPICodeUnit.Core.Constants;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPICodeUnit.Core.Controller
{
    [ApiController]
    [Route(ExampleController.ControllerRoute)]
    public class ExampleController : ControllerBase
    {
        public const string ControllerRoute = $"{ServerConfiguration.APIRoutePrefix}/v{GeneralConstants.CodeUnitMajorVersion}/{nameof(ExampleController)}";
        private readonly ISomeService _SomeService;
        private readonly IGeneralLogger _Logger;
        private readonly IPersistence _Persistence;
        public ExampleController(ISomeService someService, IGeneralLogger logger, IPersistence persistence)
        {
            this._SomeService = someService;
            this._Logger = logger;
            this._Persistence = persistence;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [Route($"{nameof(Add)}/{{{nameof(parameter1)}}}/{{{nameof(parameter2)}}}")]
        public IActionResult Add(decimal parameter1, decimal parameter2)
        {
            return this.Ok(this._SomeService.Add(parameter1,parameter2));
        }
    }
}
