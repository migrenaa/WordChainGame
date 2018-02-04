

namespace WordChainGame.Web.App_Start
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataHandler;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;
    using WordChainGame.Data.Entities;
    using WordChainGame.Data.Model;
    using WordChainGame.Services.Factory;
    using WordChainGame.Services.Repositories;
    using WordChainGame.Services.Services;

    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WordChainGameContext>()
                   .As<IdentityDbContext<User>>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerRequest();

            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerRequest();

            builder.RegisterType<SecureDataFormat<AuthenticationTicket>>()
                   .As<ISecureDataFormat<AuthenticationTicket>>()
                   .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}