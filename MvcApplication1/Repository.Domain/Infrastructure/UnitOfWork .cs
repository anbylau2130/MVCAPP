using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _context;
        public DbContext Context
        {
            get { return _context; }
        }

        public event EventHandler Disposed;

        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            Dispose(true);
        }
        public virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposing && !IsDisposed)
                {
                    _context.Dispose();
                    var evt = Disposed;
                    if (evt != null) evt(this, EventArgs.Empty);
                    Disposed = null;
                    IsDisposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        public UnitOfWork(TestDbContext context)
        {
            _context = context;
        }

        public int  Save()
        {
            try
            {
                
                return _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
