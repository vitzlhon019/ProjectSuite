using DataAccess.DBContexts.ProjectSuiteDB;
using DataAccess.DBContexts.ProjectSuiteDB.Models;
using DataAccess.Repositories._Base;
using DataAccess.Repositories.ProjectSuite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ProjectSuite
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        public UserRepository(ProjectSuiteDBContext context) : base(context) { 
        
        }
    }
}
