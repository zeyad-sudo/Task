using MS.Infrastructure.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Infrastructure.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Car> cars { get; }
        IBaseRepository<ApplicationUser> users { get; }

        Task<int> CompleteAsync();

    }
}
