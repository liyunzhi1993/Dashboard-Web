using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MoFang.MobileSite.Core.File;
using MoFang.MobileSite.Core.Model.Config;
using MoFang.MobileSite.Core.Security;
using MoFang.MobileSite.Core.Utility;
using MoFang.MobileSite.Core.Model;

namespace MoFang.MobileSite.Dashboard.Controllers
{
    public class BaseController : Controller
    {
        protected ResponseModel ResponseModel { get; set; }

        public BaseController()
        {
            ResponseModel = new ResponseModel(string.Empty,true,1001);
        }

        /// <summary>
        /// OA认证管理
        /// </summary>
        /// <value>
        /// The oa security manager.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected OASecurityManager OASecurityManager
        {
            get
            {
                return this.HttpContext.RequestServices.GetService<OASecurityManager>();
            }
        }

        /// <summary>
        /// 文件管理
        /// </summary>
        /// <value>
        /// The file manager.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected FileManager FileManager
        {
            get
            {
                return this.HttpContext.RequestServices.GetService<FileManager>();
            }
        }

        /// <summary>
        /// 写入SiteKeywords&SiteDescription
        /// </summary>
        /// <param name="context">The action executing context.</param>
        /// 时间：2018/1/17
        /// 修改：李允智
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            ViewBag.Keywords = configuration["SiteKeywords"];
            ViewBag.Description = configuration["SiteDescription"];

            base.OnActionExecuting(context);
        }
    }
}
