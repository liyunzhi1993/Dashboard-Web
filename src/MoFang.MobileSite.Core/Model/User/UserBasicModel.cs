using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoFang.MobileSite.Domain.Enums;

namespace MoFang.MobileSite.Core.Model.User
{
    public class UserBasicModel : BaseModel
    {
        public string UserName { get; set; }//用户ID

        public string Avatar { get; set; }//头像

        public string NickName { get; set; }//昵称

        public SexType Sex { get; set; }//性别

        public String BannerFileName { get; set; }

        public String Signature { get; set; }
    }
}
