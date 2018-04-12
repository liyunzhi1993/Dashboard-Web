using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Dashboard.Middlewares
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExecuteTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExecuteTimeMiddleware>();
        }
    }
}
