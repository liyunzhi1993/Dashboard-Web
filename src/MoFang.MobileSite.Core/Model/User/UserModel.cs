using Microsoft.AspNetCore.Http;
using MoFang.MobileSite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Core.Model.User
{
    public class UserModel : UserBasicModel
    {
        public IFormFile AvatarFile { get; set; }
    }
}
