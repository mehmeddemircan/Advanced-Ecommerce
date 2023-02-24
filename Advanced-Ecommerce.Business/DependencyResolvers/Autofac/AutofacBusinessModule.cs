using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Business.Concrete;
using Advanced_Ecommerce.Core.Utilities.Interceptors;
using Advanced_Ecommerce.Core.Utilities.Security.JWT;

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

        

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<ColorRepository>().As<IColorRepository>();

            builder.RegisterType<ProductColorManager>().As<IProductColorService>();
            builder.RegisterType<ProductColorRepository>().As<IProductColorRepository>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<ModelRepository>().As<IModelRepository>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>();
            builder.RegisterType<SubCategoryRepository>().As<ISubCategoryRepository>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
