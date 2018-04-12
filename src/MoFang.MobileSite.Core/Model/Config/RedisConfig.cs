using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.MobileSite.Core.Model.Config
{
    public class RedisConfig
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public int Db { get; set; }
    }
}
