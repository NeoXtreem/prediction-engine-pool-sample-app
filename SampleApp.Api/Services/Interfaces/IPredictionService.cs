using System.Collections.ObjectModel;
using SampleApp.Api.Models;

namespace SampleApp.Api.Services.Interfaces
{
    public interface IPredictionService
    {
        bool CanPredict(string modelType);

        ReadOnlyCollection<Foo> Predict();
    }
}
