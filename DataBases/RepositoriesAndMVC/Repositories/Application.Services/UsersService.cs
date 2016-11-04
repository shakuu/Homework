using SqlModels;
using Repositories.Contracts;
using Services.Factories;
using System.Collections.Generic;

namespace Application.Services
{
    public class UsersService
    {
        private readonly IRepository<User> usersRepository;
        private readonly IUserFactory userFactory;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public UsersService(IRepository<User> usersRepository, IUserFactory userFactory, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.usersRepository = usersRepository;
            this.userFactory = userFactory;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void CreateUser(string username)
        {
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                var newUser = this.userFactory.CreateUser(username);
                this.usersRepository.Add(newUser);

                unitOfWork.Commit();
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = this.usersRepository.GetAll();
            return users;
        }
    }
}
