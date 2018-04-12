using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MoFang.MobileSite.Core.Model;
using MoFang.MobileSite.Core.Model.User;
using MoFang.MobileSite.Dashboard.ViewModels.Home;
using MoFang.MobileSite.Core.Service;

namespace MoFang.MobileSite.Dashboard.Controllers
{
    /// <summary>
    /// 首页（动态）
    /// </summary>
    [Filters.RequireLogin]
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("photo")]
        //public IActionResult Photo()
        //{
        //    PhotoViewModel photoViewModel = new PhotoViewModel();
        //    photoViewModel.User = SecurityManager.CurrentUser;
        //    return View(photoViewModel);
        //}

        ///// <summary>
        ///// 上传banner
        ///// </summary>
        ///// <param name="bannerFile">The banner file.</param>
        ///// <returns></returns>
        //[HttpPost("uploadbanner")]
        //public async Task<IActionResult> UploadBanner(IFormFile bannerFile)
        //{
        //    string filename = await FileManager.UploadFileSingle(bannerFile, FileManager.ImagePathConfigAccessor.BannerPath,SecurityManager.CurrentUser.ID);
        //    EditUserInfoModel editUserInfoModel=new EditUserInfoModel();
        //    editUserInfoModel.BannerFileName = filename;
        //    var result=await UserService.EditUserInfo(SecurityManager.CurrentUser.ID, editUserInfoModel);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// 发送动态
        ///// </summary>
        ///// <param name="timeLineImageFile">The time line image file.</param>
        ///// <param name="timeLineRequestModel">The time line request model.</param>
        ///// <returns></returns>
        //[HttpPost("posttimeline")]
        //public async Task<IActionResult> PostTimeLine(IFormFile timeLineImageFile, TimeLineRequestModel timeLineRequestModel)
        //{
        //    TimeLineModel timeLineModel = new TimeLineModel();
        //    timeLineModel.Content = timeLineRequestModel.Content;
        //    timeLineModel.Images = new List<TimeLineImageModel>();
        //    timeLineModel.UserId = SecurityManager.CurrentUser.ID;

        //    if (timeLineImageFile != null)
        //    {
        //        timeLineModel.Images.Add(new TimeLineImageModel { ImagePath = await FileManager.UploadFileSingle(timeLineImageFile, FileManager.ImagePathConfigAccessor.TimeLineImagePath,SecurityManager.CurrentUser.ID) });
        //    }
        //    var result=await TimeLineService.PostTimeLine(timeLineModel,SecurityManager.CurrentUser.ID);
        //    return View("index");
        //}

        ///// <summary>
        ///// 获取动态列表
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("gettimelinelist")]
        //public async Task<IActionResult> GetTimeLineList()
        //{
        //    var result =await TimeLineService.GetTimeLineList(SecurityManager.CurrentUser.ID);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// 获取相册列表
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("getphotolist")]
        //public async Task<IActionResult> GetPhotoList()
        //{
        //    var result = await PhotoService.GetPhotoList(SecurityManager.CurrentUser.ID);
        //    return Ok(result);
        //}
    }
}
