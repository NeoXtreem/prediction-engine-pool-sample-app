using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.ML;
using SampleApp.Api.Attributes;
using SampleApp.Api.Models;
using SampleApp.Api.Services.Interfaces;

namespace SampleApp.Api.Services
{
    [Inject]
    internal class TimeSeriesPredictionService : IPredictionService
    {
        public TimeSeriesPredictionService(LazyService<PredictionEnginePool<FooInput, FooTimeSeriesPrediction>> lazyPredictionEnginePool)
        {
        }

        public bool CanPredict(string modelType) => modelType == "TimeSeries";

        public ReadOnlyCollection<Foo> Predict() => throw new NotImplementedException();
    }
}
