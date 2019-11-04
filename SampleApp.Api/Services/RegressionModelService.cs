using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.ML;
using SampleApp.Api.Attributes;
using SampleApp.Api.Services.Interfaces;
using SampleApp.Api.Types;

namespace SampleApp.Api.Services
{
    [Inject]
    internal class RegressionModelService : IModelService
    {
        public bool CanTrain(Type type) => type.GetCustomAttribute<PredictionModelAttribute>().PredictionModel == PredictionModel.Regression;

        public ITransformer Train<TOutput>(IEnumerable<TOutput> items) where TOutput : class => throw new NotImplementedException();
    }
}
