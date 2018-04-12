using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoFang.MobileSite.Domain.Consts;
using MoFang.MobileSite.Core.Model.Config;
using MoFang.MobileSite.Core.Redis;
using Microsoft.Extensions.Options;
using MoFang.MobileSite.Core.Security;
using AutoMapper;

namespace MoFang.MobileSite.Core.Service
{
    public abstract class ServiceBase
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        public ServiceBase(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        protected IMapper MapperProvider
        {
            get
            {
                return this.ServiceProvider.GetService<Mapper>();
            }
        }

        /// <summary>
        /// 站点配置
        /// </summary>
        /// <value>
        /// The site configuration.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected SiteConfiguration SiteConfiguration
        {
            get
            {
                return this.ServiceProvider.GetService<IOptions<SiteConfiguration>>().Value;
            }
        }

        /// <summary>
        /// 移动后台配置
        /// </summary>
        /// <value>
        /// The dashboard configuration.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected DashboardConfig DashboardConfig
        {
            get
            {
                return this.ServiceProvider.GetService<IOptions<DashboardConfig>>().Value;
            }
        }

        /// <summary>
        /// 七牛配置
        /// </summary>
        /// <value>
        /// The qiniu configuration.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected QiniuConfig QiniuConfig
        {
            get
            {
                return this.ServiceProvider.GetService<IOptions<QiniuConfig>>().Value;
            }
        }

        /// <summary>
        /// RedisProvider
        /// </summary>
        /// <value>
        /// The redis provider.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected IRedisProvider RedisProvider
        {
            get
            {
                return this.ServiceProvider.GetService<IRedisProvider>();
            }
        }

        /// <summary>
        /// OA认证管理
        /// </summary>
        /// <value>
        /// The security manager.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        protected OASecurityManager OASecurityManager
        {
            get
            {
                return this.ServiceProvider.GetService<Security.OASecurityManager>();
            }
        }
    }
}
