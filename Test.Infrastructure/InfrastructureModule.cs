using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Features.Training.Services;
using Test.Infrastructure.Features.Training.Services;

namespace Test.Infrastructure
{
    public class InfrastructureModule:Module
    {
        public InfrastructureModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MedicineService>().As<IMedicineService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
