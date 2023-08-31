using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Features.Products.Repositories;
using Test.Domain.UnitOfWork;

namespace Test.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IMedicineRepository Medicines { get; }
    }
}
