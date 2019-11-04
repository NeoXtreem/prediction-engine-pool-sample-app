using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.ML;
using SampleApp.Api.Attributes;
using SampleApp.Api.Models;
using SampleApp.Api.Services.Interfaces;

namespace SampleApp.Api.Services
{
    [Inject]
    internal class RegressionPredictionService : IPredictionService
    {
        public RegressionPredictionService(LazyService<PredictionEnginePool<FooInput, FooRegressionPrediction>> lazyPredictionEnginePool)
        {
        }

        public bool CanPredict(string modelType) => modelType == "Regression";

        public ReadOnlyCollection<Foo> Predict() => throw new NotImplementedException();
    }
}
