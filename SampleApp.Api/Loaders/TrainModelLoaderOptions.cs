using SampleApp.Api.Services.Interfaces;

namespace SampleApp.Api.Loaders
{
    internal class TrainModelLoaderOptions
    {
        public IModelService ModelService { get; set; }
    }
}
