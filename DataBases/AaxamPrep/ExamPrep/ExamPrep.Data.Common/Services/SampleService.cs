using System;
using System.Collections.Generic;

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
        private readonly ISampleModelFactory sampleModelFactory;

        public SampleService(
            IRepository<SampleModel> repository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ISampleModelFactory sampleModelFactory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            }

            if (sampleModelFactory == null)
            {
                throw new ArgumentNullException(nameof(sampleModelFactory));
            }

            this.repository = repository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.sampleModelFactory = sampleModelFactory;
        }

        public IEnumerable<SampleModel> All()
        {
            return this.repository.All();
        }

        public SampleModel CreateSampleModel(string name, DateTime dateJoined, int age)
        {
            var newSampleModelInstance = this.sampleModelFactory.CreateSampleModel();
            newSampleModelInstance.Name = name;
            newSampleModelInstance.DateJoined = dateJoined;
            newSampleModelInstance.Age = age;

            using (var uow = this.unitOfWorkFactory.GetEfUnitOfWork())
            {
                this.repository.Add(newSampleModelInstance);
                uow.Commit();
            }

            return newSampleModelInstance;
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
            var sampleModel = this.repository.Find(id);
            if (sampleModel == null)
            {
                sampleModel = this.sampleModelFactory.CreateSampleModel();
            }

            return sampleModel;
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
