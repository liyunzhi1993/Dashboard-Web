using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MoFang.MobileSite.Core.Model;
using MoFang.MobileSite.Domain.Entity;

namespace MoFang.MobileSite.Core
{
    /// <summary>
    /// Mapper配置
    /// </summary>
    /// 时间：2018/2/5
    /// 修改：李允智
    /// <seealso cref="AutoMapper.Profile" />
    public sealed class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<BannerModel, Banner>();
            CreateMap<Banner, BannerModel>();
        }
    }
}
