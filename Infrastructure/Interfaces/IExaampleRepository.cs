using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IExaampleRepository : IAsyncRepository<ExampleEntity, int>
    {
       Task Insert(ExampleEntity example);

        Task Update(ExampleEntity example);

        Task Delete(int id);

        Task<List<ExampleEntity>> Reaad();
    }
}
