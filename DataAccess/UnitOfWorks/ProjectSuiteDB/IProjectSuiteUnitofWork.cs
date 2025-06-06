using DataAccess.Repositories.ProjectSuite.Interfaces;
using DataAccess.UnitOfWorks._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks.ProjectSuiteDB
{
    public interface IProjectSuiteUnitofWork : IBaseUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
