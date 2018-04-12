﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.MobileSite.Core.Model.Config
{
    public class SiteConfiguration
    {
        public string Host { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string[] AdminUserList { get; set; }

        public bool AllowRegister { get; set; }

        public bool VerifyRegisterUser { get; set; }
    }
}
