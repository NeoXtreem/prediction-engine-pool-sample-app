using System;
using SampleApp.Api.Types;

namespace SampleApp.Api.Attributes
{
    public class PredictionModelAttribute : Attribute
    {
        public PredictionModel PredictionModel { get; }

        public PredictionModelAttribute(PredictionModel predictionModel)
        {
            PredictionModel = predictionModel;
        }
    }
}
