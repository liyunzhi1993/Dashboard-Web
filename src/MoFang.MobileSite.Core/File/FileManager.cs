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
using MoFang.MobileSite.Core.Utility;

namespace MoFang.MobileSite.Core.File
{
    public sealed class FileManager
    {
        private IServiceProvider ServiceProvider { get; set; }
        public FileManager(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this._dashboardConfig = serviceProvider.GetService<IOptions<DashboardConfig>>();
            this._qiniuConfig = serviceProvider.GetService<IOptions<QiniuConfig>>();
            this._hostEnv = serviceProvider.GetService<IHostingEnvironment>();
        }
         

        private IOptions<DashboardConfig> _dashboardConfig;


        public DashboardConfig DashboardConfig
        {
            get
            {
                return _dashboardConfig.Value;
            }
        }

        private IOptions<QiniuConfig> _qiniuConfig;

        public QiniuConfig QiniuConfig
        {
            get
            {
                return _qiniuConfig.Value;
            }
        }

        private IHostingEnvironment _hostEnv;

        private IHostingEnvironment HostEnv
        {
            get
            {
                return _hostEnv;
            }
        }

        public string UploadFileSingle(IFormFile file,string userId)
        {
            Random rnd = new Random();
            string extension = Path.GetExtension(file.FileName);
            int num = rnd.Next(5000, 1000000);
            var filename = userId +DateTime.Now.ToString("yyyyMMddHHmmss")+ num.ToString() + extension;
            return QiniuHelper.UploadFile(file.OpenReadStream(), filename, QiniuConfig.AK, QiniuConfig.SK, QiniuConfig.Bucket);
        }
    }
}
