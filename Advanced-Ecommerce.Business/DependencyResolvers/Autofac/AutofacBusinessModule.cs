using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Concrete;
using Advanced_Ecommerce.Core.Utilities.Interceptors;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
