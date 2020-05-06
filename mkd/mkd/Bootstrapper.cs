using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Services.Interfaces;
using Repository.Interfaces;
using Repository.Repositories;
using Services.Services;


namespace mkd
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            AutoFacContainerBuilder();
        }
        public static void AutoFacContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<JobPostingRepository>().As<IJobPostingRepository>().InstancePerRequest();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerRequest();
            builder.RegisterType<RegionRepository>().As<IRegionRepository>().InstancePerRequest();
            builder.RegisterType<JobPostingService>().As<IJobPostingService>().InstancePerRequest();
            builder.RegisterType<DisplayPostService>().As<IDisplayPostService>().InstancePerRequest();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerRequest();
            builder.RegisterType<RegionService>().As<IRegionService>().InstancePerRequest();
            builder.RegisterFilterProvider(); //avtomatski gi registrira site atributi
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}