using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.Application;
using Test.Application.Features.Training.Services;
using Test.Domain.Entities;

namespace Test.Infrastructure.Features.Training.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public MedicineService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateMedicine(string MedicineName, decimal Price, int Quantity, string Category)
        {
            Medicine medicine = new Medicine()
            {
                MedicineName = MedicineName,
                Price = Price,
                Quantity= Quantity,
                Category = Category
            };

            _unitOfWork.Medicines.Add(medicine);
            _unitOfWork.Save();
        }
    }
}
