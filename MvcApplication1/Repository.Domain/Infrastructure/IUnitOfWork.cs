using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        int Save();
        bool IsDisposed { get; }
    }
}
