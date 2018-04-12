using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoFang.MobileSite.Core
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder); 

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = Assembly.Load(new AssemblyName("MoFang.MobileSite.Core"));
            foreach (var typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.Name.EndsWith("Service"))
                {
                    builder.RegisterType(typeInfo.AsType());
                }
            }
        }
    }
}
