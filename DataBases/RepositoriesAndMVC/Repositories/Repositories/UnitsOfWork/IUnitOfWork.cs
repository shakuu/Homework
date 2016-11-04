using System;

namespace Repositories.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}