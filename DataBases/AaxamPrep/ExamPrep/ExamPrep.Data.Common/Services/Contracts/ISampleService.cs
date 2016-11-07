using ExamPrep.Data.Common.SampleModels;

namespace ExamPrep.Data.Common.Services.Contracts
{
    public interface ISampleService : IService<SampleModel>
    {
        SampleModel CreateSampleModel(string name);
    }
}
