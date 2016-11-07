using ExamPrep.Data.Common.UnitsOfWork.Contracts;

namespace ExamPrep.Data.Common.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetEfUnitOfWork();
    }
}
