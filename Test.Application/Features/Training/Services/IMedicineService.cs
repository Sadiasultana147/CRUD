using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Features.Training.Services
{
    public interface IMedicineService
    {
        void CreateMedicine(string MedicineName, decimal Price, int Quantity, string Category);
    }
}
