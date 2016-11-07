using System;
using System.Data.Entity;

using ExamPrep.Data.Common.UnitsOfWork.Contracts;

namespace ExamPrep.Data.Common.UnitsOfWork
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext efContext;

        public EfUnitOfWork(DbContext efContext)
        {
            if (efContext == null)
            {
                throw new ArgumentNullException(nameof(efContext));
            }

            this.efContext = efContext;
        }

        public void Commit()
        {
            this.efContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
