using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MoFang.MobileSite.Core.Model.User;
using MoFang.MobileSite.Core.Service;
using MoFang.MobileSite.Dashboard.ViewModels.My;
using MoFang.MobileSite.Core.Model;

namespace MoFang.MobileSite.Dashboard.Controllers
{
    /// <summary>
    /// 个人用户信息页面
    /// </summary>
    /// 时间：2018/2/6
    /// 修改：李允智
    /// <seealso cref="MoFang.MobileSite.Dashboard.Controllers.BaseController" />
    [Filters.RequireLogin]
    public class MyController : BaseController
    {
        private OAAuthService OAAuthService { get; set; }

        public MyController(OAAuthService oaAuthService)
        {
            this.OAAuthService = oaAuthService;
        }

        /// <summary>
        /// 编辑个人资料页面
        /// </summary>
        /// <returns></returns>
        /// 时间：2018/1/17
        /// 修改：李允智
        public IActionResult Edit()
        {
            var vm = new EditViewModel();
            vm.UserModel = OASecurityManager.CurrentUser;
            return View(vm);
        }

        /// <summary>
        /// 保存个人资料
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// 时间：2018/1/17
        /// 修改：李允智
        public async Task<IActionResult> Save(UserModel user)
        {
            var vm = new EditViewModel();
            vm.UserModel = OASecurityManager.CurrentUser;
            if (user.AvatarFile != null)
            {
                string filename = FileManager.UploadFileSingle(user.AvatarFile, OASecurityManager.CurrentUser.UserName);
                vm.UserModel.Avatar = filename;
            }
            var result=await OAAuthService.EditUserInfo(OASecurityManager.CurrentUser.UserName, user);
            return View("Edit", vm);
        }
    }
}