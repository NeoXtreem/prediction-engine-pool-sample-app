using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SampleApp.Api.Models;
using SampleApp.Api.Services.Interfaces;

namespace SampleApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MLController : ControllerBase
    {
        private readonly ModelOptions _options;
        private readonly IEnumerable<IPredictionService> _predictionServices;

        public MLController(IOptionsFactory<ModelOptions> optionsFactory, IEnumerable<IPredictionService> predictionServices)
        {
            _options = optionsFactory.Create(Options.DefaultName);
            _predictionServices = predictionServices;
        }

        [HttpPost]
        public ActionResult<ReadOnlyCollection<Foo>> Post()
        {
            return Ok(_predictionServices.Single(s => s.CanPredict(_options.Type)).Predict());
        }
    }
}
