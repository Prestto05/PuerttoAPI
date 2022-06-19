using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }

        TService Repository<TService, TImplementation>() where TService : class where TImplementation : class, TService;

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
