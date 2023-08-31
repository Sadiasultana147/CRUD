using Autofac;
using Test.Web.Models;

namespace Test.Web
{
    public class WebModule:Module
    {
        public WebModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MedicineCreateModel>().AsSelf()
                .InstancePerLifetimeScope();

            
            base.Load(builder);
        }
    }
}
