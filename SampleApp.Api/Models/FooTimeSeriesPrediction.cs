using SampleApp.Api.Attributes;
using SampleApp.Api.Types;

namespace SampleApp.Api.Models
{
    [PredictionModel(PredictionModel.TimeSeries)]
    public class FooTimeSeriesPrediction
    {
        public float[] LabelPrediction;
    }
}
