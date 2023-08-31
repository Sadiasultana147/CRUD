using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Persistance
{
    public interface IApplicationDbContext
    {
        public DbSet <Medicine> Medicines { get; set; }
    }
}
