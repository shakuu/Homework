using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories
{
  public  interface IUserFactory
    {
        User CreateUser(string username);
    }
}
