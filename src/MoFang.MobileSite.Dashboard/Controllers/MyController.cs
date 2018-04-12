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
    /// �����û���Ϣҳ��
    /// </summary>
    /// ʱ�䣺2018/2/6
    /// �޸ģ�������
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
        /// �༭��������ҳ��
        /// </summary>
        /// <returns></returns>
        /// ʱ�䣺2018/1/17
        /// �޸ģ�������
        public IActionResult Edit()
        {
            var vm = new EditViewModel();
            vm.UserModel = OASecurityManager.CurrentUser;
            return View(vm);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// ʱ�䣺2018/1/17
        /// �޸ģ�������
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