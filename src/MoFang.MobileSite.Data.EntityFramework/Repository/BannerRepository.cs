using Microsoft.EntityFrameworkCore;
using MoFang.MobileSite.Domain.Entity;
using MoFang.MobileSite.Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MoFang.MobileSite.Data.EntityFramework.Repository
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }
    }
}
