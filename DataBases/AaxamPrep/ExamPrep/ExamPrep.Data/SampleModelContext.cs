using System.Data.Entity;

using ExamPrep.Data.Common.SampleModels;

namespace ExamPrep.Data
{
    public class SampleModelContext : DbContext
    {
        public virtual IDbSet<SampleModel> Samples { get; set; }
    }
}
