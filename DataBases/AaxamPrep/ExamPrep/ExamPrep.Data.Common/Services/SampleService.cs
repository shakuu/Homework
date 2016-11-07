using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.Common.SampleModels;
using ExamPrep.Data.Common.Services.Contracts;
using ExamPrep.Data.Common.Repositories.Contracts;
using ExamPrep.Data.Common.Factories;

namespace ExamPrep.Data.Common.Services
{
    public class SampleService : ISampleService
    {
        private readonly IRepository<SampleModel> repository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public SampleService(IRepository<SampleModel> repository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            }

            this.repository = repository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<SampleModel> All()
        {
            return this.repository.All();
        }

        public SampleModel CreateSampleModel(string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(SampleModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            using (var uow = this.unitOfWorkFactory.GetEfUnitOfWork())
            {
                this.repository.Delete(instance);
                uow.Commit();
            }
        }

        public SampleModel Find(object id)
        {
            return this.repository.Find(id);
        }

        public SampleModel FindOrCreate(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(SampleModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            using (var uow = this.unitOfWorkFactory.GetEfUnitOfWork())
            {
                this.repository.Update(instance);
                uow.Commit();
            }
        }
    }
}
