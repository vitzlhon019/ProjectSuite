using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks._Base
{
    public interface IBaseUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
