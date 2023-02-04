using Dependency_Injection_explained.Interfaces;
using Dependency_Injection_explained.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;


namespace Dependency_Injection_explained
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            




            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPerson, PersonRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}