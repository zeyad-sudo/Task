using Tsk.Infrastructure.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Data.Entities;

namespace Tsk.Infrastructure.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Car> cars { get; }
        IBaseRepository<ApplicationUser> users { get; }
        IBaseRepository<UserCar> userCars { get; }

        Task<int> CompleteAsync();

    }
}
