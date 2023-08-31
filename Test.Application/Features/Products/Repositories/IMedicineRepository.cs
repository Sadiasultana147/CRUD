using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Repositories;

namespace Test.Application.Features.Products.Repositories
{
    public interface IMedicineRepository:IRepositoryBase<Medicine, int>
    {
    }
}
