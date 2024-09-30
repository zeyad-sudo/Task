using Tsk.Infrastructure.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Contexts;

namespace Tsk.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IBaseRepository<Car> cars { get; private set; }

        public IBaseRepository<ApplicationUser> users { get; private set; }
        public IBaseRepository<UserCar> userCars { get; private set; }
        public UnitOfWork(Context context)
        {
            _context = context;
            cars = new BaseRepository<Car>(_context);
            users = new BaseRepository<ApplicationUser>(_context);
            userCars = new BaseRepository<UserCar>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
