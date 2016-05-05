using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApi.Controllers;
using WebApi.Models.Rituals;
using VillageRepository = WebApi.Models.Villages.VillageRepository;

namespace WebApi
{
    public static class IoC
    {
        public static void SetupIoc(this HttpConfiguration configuration)
        {
            var container = BuildContainer(configuration);
            SetupConfiguration(container, configuration);
        }

        private static void SetupConfiguration(ILifetimeScope container, HttpConfiguration configuration)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer BuildContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof (VillageController).Assembly).InstancePerRequest();
            builder.RegisterHttpRequestMessage(configuration);

            builder.RegisterInstance(new VillageRepository()).AsImplementedInterfaces();
            builder.RegisterInstance(new RitualRepository()).AsImplementedInterfaces();

            return builder.Build();
        }
    }
}