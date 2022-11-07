using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GulaylarCase.Business.Abstract;
using GulaylarCase.Business.Concrete;
using GulaylarCase.Core.Abstract;
using GulaylarCase.Core.Concrete;
using Ninject;

namespace GulaylarCase.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(CreateKernel());

        }


        private IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ISubscribeService>().To<SubscribeService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IWatchHistoryService>().To<WatchHistoryService>();

            kernel.
                Bind(typeof(IRepository<>)).
                To(typeof(Repository<>));

            return kernel;
        }
    }
}
