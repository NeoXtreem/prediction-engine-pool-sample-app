using System;
using System.Collections.Generic;
using Microsoft.ML;

namespace SampleApp.Api.Services.Interfaces
{
    internal interface IModelService
    {
        bool CanTrain(Type type);

        ITransformer Train<TOutput>(IEnumerable<TOutput> items) where TOutput : class;
    }
}
