using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private bool _disposed;
        private IDbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;


        public UnitOfWork(Func<TContext> factory) => _context = factory();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TContext Context
        {
            get { return _context; }
        }

        public void BeginTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public TService Repository<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();
            var type = typeof(TImplementation).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeof(TImplementation), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (TService)_repositories[type];
        }
    }
}
