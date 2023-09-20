using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
    }
}