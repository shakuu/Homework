using System;

namespace ExamPrep.Data.Common.UnitsOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
