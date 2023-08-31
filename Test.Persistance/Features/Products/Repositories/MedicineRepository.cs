using Microsoft.EntityFrameworkCore;

using Test.Application.Features.Products.Repositories;
using Test.Domain.Entities;

namespace Test.Persistance.Features.Products.Repositories
{
    public class MedicineRepository : Repository<Medicine, int>, IMedicineRepository
    {
        public MedicineRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
        public Medicine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Medicine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

   
}

