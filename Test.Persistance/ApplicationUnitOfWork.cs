using Microsoft.EntityFrameworkCore;
using System;
using Test.Application;
using Test.Application.Features.Products.Repositories;

namespace Test.Persistance
{
    public class ApplicationUnitOfWork:UnitOfWork, IApplicationUnitOfWork
    {
        public IMedicineRepository Medicines { get; set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IMedicineRepository medicineRepository) : base((DbContext)dbContext)
        {
            Medicines = medicineRepository;
        }

        
    }
}
