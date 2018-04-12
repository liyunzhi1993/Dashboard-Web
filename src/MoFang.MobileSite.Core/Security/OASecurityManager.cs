using MoFang.MobileSite.Core.Model.User;
using MoFang.MobileSite.Core.Service;
using MoFang.MobileSite.Domain.Consts;
using MoFang.MobileSite.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoFang.MobileSite.Core.Redis;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using MoFang.MobileSite.Core.Model.Config;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Core.Security
{
    public sealed class OASecurityManager
    {
        private const string TOKEN_KEY = "OAToken";
        private object _sync = new object();
        private bool _loaded = false;
        private UserModel _user;
        private IServiceProvider ServiceProvider { get; set; }
        public string Token { get; private set; }

        public OASecurityManager(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// HttpContextAccessor
        /// </summary>
        /// <value>
        /// The HTTP context accessor.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        private IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                return this.ServiceProvider.GetService<IHttpContextAccessor>();
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
        private IRedisProvider RedisProvider
        {
            get
            {
                return this.ServiceProvider.GetService<IRedisProvider>();
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
        private SiteConfiguration SiteConfiguration
        {
            get
            {
                return ServiceProvider.GetService<IOptions<SiteConfiguration>>().Value;
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        public UserModel CurrentUser
        {
            get
            {
                if (!_loaded)
                {
                    lock (_sync)
                    {
                        if (!_loaded)
                        {
                            this.LoadUser();
                            _loaded = true;
                        }
                    }
                }

                return _user;
            }
        }


        /// <summary>
        /// 是否登录
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is login; otherwise, <c>false</c>.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        public bool IsLogin
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        /// <summary>
        /// 是否是管理员
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin; otherwise, <c>false</c>.
        /// </value>
        /// 时间：2018/1/17
        /// 修改：李允智
        public bool IsAdmin
        {
            get
            {
                return this.IsLogin && this.SiteConfiguration.AdminUserList?.Contains(this.CurrentUser.UserName) == true;
            }
        }


        /// <summary>
        /// 加载用户信息
        /// </summary>
        /// 时间：2018/1/17
        /// 修改：李允智
        private void LoadUser()
        {
            this.InitToken();
            if (string.IsNullOrWhiteSpace(this.Token))
            {
                return;
            }

            var redis = this.RedisProvider.GetDatabase();
            string tokenKey = RedisKeys.GetTokenCacheKey(this.Token);
            var id = redis.StringGet(tokenKey);

            if (id.HasValue)
            {
                var oaAuthService = this.ServiceProvider.GetService<OAAuthService>();
                _user = oaAuthService.Get(id.ToString());
            }
        }

        /// <summary>
        /// 初始化Token
        /// </summary>
        /// 时间：2018/1/17
        /// 修改：李允智
        private void InitToken()
        {
            if (this.HttpContextAccessor.HttpContext == null)
            {
                return;
            }

            string token = this.HttpContextAccessor.HttpContext.Request.Query[TOKEN_KEY];
            if (string.IsNullOrWhiteSpace(token))
            {
                if (this.HttpContextAccessor.HttpContext.Request.Headers.ContainsKey(TOKEN_KEY))
                {
                    token = this.HttpContextAccessor.HttpContext.Request.Headers[TOKEN_KEY].FirstOrDefault();
                }
            }
            if (string.IsNullOrWhiteSpace(token))
            {
                token = this.HttpContextAccessor.HttpContext.Request.Cookies[TOKEN_KEY];
            }

            this.Token = token;
        }

        /// <summary>
        /// 写入Token
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="token">The token.</param>
        /// <param name="rememberPassword">if set to <c>true</c> [remember password].</param>
        /// 时间：2018/1/17
        /// 修改：李允智
        public void WriteToken(HttpContext context, string token, bool rememberPassword)
        {
            var cookieOptions = new CookieOptions();
            if (rememberPassword)
            {
                cookieOptions.Expires = DateTime.Now.AddDays(30);
            }
            context.Response.Cookies.Append(TOKEN_KEY, token, cookieOptions);
        }

        /// <summary>
        /// 清除Token
        /// </summary>
        /// <param name="context">The context.</param>
        /// 时间：2018/1/17
        /// 修改：李允智
        public void ClearToken(HttpContext context)
        {
            context.Response.Cookies.Append(TOKEN_KEY, string.Empty, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
        }
    }
}
