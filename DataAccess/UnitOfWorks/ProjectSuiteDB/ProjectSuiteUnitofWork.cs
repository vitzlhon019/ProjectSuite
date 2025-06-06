using DataAccess.DBContexts.ProjectSuiteDB;
using DataAccess.Repositories.ProjectSuite;
using DataAccess.Repositories.ProjectSuite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks.ProjectSuiteDB
{
    public class ProjectSuiteUnitofWork : IProjectSuiteUnitofWork
    {
        private readonly ProjectSuiteDBContext _context;
        public ProjectSuiteUnitofWork(ProjectSuiteDBContext context) { 
            _context = context;
            UserRepository = new UserRepository(_context);
        }
        public IUserRepository UserRepository { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
