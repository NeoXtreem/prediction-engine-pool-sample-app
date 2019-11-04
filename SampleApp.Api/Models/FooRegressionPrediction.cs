using SampleApp.Api.Attributes;
using SampleApp.Api.Types;

namespace SampleApp.Api.Models
{
    [PredictionModel(PredictionModel.Regression)]
    public class FooRegressionPrediction
    {
        public float LabelPrediction;
    }
}
