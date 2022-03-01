using Autofac;
using Autofac.Integration.Mvc;
using GetClientIP.ActionFilter;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GetClientIP
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var builder = new ContainerBuilder();
            RegisterAspNetMvc(builder);
            var service = Assembly.Load("GetClientIP");
            builder.RegisterAssemblyTypes(service).Where(w => w.Name.EndsWith("Service")
            && !w.GetCustomAttributes(true).Where(t => t is MockServiceAttribute).Any())
            .AsImplementedInterfaces();
            string isRegisterMockService = ConfigurationManager.AppSettings["isRegisterMockService"];

            if (isRegisterMockService == "true")
            {
                GetMockService(builder, service);
            }
            
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterAspNetMvc(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
        }

        private static void GetMockService(ContainerBuilder builder, Assembly service)
        {
            builder.RegisterAssemblyTypes(service).Where(w => w.Name.EndsWith("Service")
            && w.GetCustomAttributes(true).Where(t => t is MockServiceAttribute).Any())
           .AsImplementedInterfaces();
        }
    }
}
