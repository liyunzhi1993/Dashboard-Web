using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoFang.MobileSite.Core.Model.User;

namespace MoFang.MobileSite.Dashboard.ViewComponents
{
    public class GuildBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UserModel userModel)
        {
            return this.View(userModel);
        }
    }
}
