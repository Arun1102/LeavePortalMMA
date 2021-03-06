using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using LeavePortalMMA.ServiceLayers;
using System.Web.Mvc;

namespace LeavePortalMMA
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			
            var container = new UnityContainer();
            container.RegisterType<ILeaveApplyService, LeaveApplyService>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<ICategoriesServiceLayer, CategoriesServiceLayer>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}