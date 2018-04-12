using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoFang.MobileSite.Core.Service;
using MoFang.MobileSite.Core.Model;
using MoFang.MobileSite.Dashboard.ViewModels.Account;
using MoFang.MobileSite.Core.Model.User;
using MoFang.MobileSite.Core.Security;

namespace MoFang.MobileSite.Dashboard.Controllers
{
    public class AccountController : BaseController
    {
        private OAAuthService OAAuthService { get; set; }

        public AccountController(OAAuthService oaAuthService)
        {
            this.OAAuthService = oaAuthService;
        }

        /// <summary>
        /// ��¼ҳ��
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        /// ʱ�䣺2018/1/17
        /// �޸ģ�������
        public IActionResult Login(string returnUrl = null)
        {
            var vm = new LoginViewModel();
            vm.LoginModel = new LoginModel();
            vm.LoginModel.RememberPassword = true;
            ViewBag.ReturnUrl = returnUrl;
            return View(vm);
        }


        /// <summary>
        /// ��¼POST
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        /// ʱ�䣺2018/1/17
        /// �޸ģ�������
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<JsonResult> Login(LoginModel model, string returnUrl = null)
        {
            var vm = new LoginViewModel();
            vm.LoginModel = model;

            var result = await this.OAAuthService.OALogin(model);

            if (result.Success)
            {
                OASecurityManager.WriteToken(this.HttpContext, result.Data, model.RememberPassword);
            }
            else
            {
                ResponseModel.Message = "�û��������벻��ȷ";
            }
          
            return Json(ResponseModel);
        }

        /// <summary>
        /// �ǳ�
        /// </summary>
        /// <returns></returns>
        /// ʱ�䣺2018/1/17
        /// �޸ģ�������
        public ActionResult LogOff()
        {
            OASecurityManager.ClearToken(this.HttpContext);
            return this.RedirectToAction("Index", "Home");
        }
    }
}