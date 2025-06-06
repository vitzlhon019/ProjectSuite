using DataAccess.DBContexts.ProjectSuiteDB.Models;
using DataAccess.Repositories._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ProjectSuite.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
    }
}
