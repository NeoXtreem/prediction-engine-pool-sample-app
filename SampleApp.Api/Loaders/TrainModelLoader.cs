using System.Threading;
using Microsoft.Extensions.ML;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.ML;
using SampleApp.Api.Attributes;
using SampleApp.Api.Models;

namespace SampleApp.Api.Loaders
{
    [Inject]
    internal class TrainModelLoader : ModelLoader
    {
        private readonly TrainModelLoaderOptions _options;

        public TrainModelLoader(IOptionsFactory<TrainModelLoaderOptions> optionsFactory)
        {
            _options = optionsFactory.Create(Options.DefaultName);
        }

        public override ITransformer GetModel()
        {
            return _options.ModelService.Train(new[] {new FooInput()}); // This passes a much larger data set in the real application.
        }

        public override IChangeToken GetReloadToken() => new CancellationChangeToken(CancellationToken.None);
    }
}
