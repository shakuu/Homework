using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories
{
    public interface IDataServiceFactory
    {
        UsersService CreateUsersService();
    }
}
