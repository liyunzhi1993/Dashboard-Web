using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.MobileSite.Core.Model.OA
{
    public class SsoAuthurizationModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string expires_in { get; set; }

        public string userName { get; set; }

    }

    public class RequestAuthurizationModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
