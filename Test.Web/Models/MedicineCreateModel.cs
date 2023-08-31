
using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;
using Test.Application.Features.Training.Services;

namespace Test.Web.Models
{
    public class MedicineCreateModel
    {
        [Required]
        public string MedicineName { get; set; }
        [Required, Range(0, 50000, ErrorMessage = "Fees should be between 0 & 50000")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        private IMedicineService _medicineService;

        public MedicineCreateModel()
        {

        }

        public MedicineCreateModel(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _medicineService = scope.Resolve<IMedicineService>();
        }

        internal void CreateMedicine()
        {
            if (!string.IsNullOrWhiteSpace(MedicineName)
                && Price >= 0)
            {
                _medicineService.CreateMedicine(MedicineName, Price, Quantity, Category);
            }
        }
    }
}
