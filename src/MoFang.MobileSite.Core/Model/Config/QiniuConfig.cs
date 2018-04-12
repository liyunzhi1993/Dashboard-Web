using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.MobileSite.Core.Model.Config
{
    public class QiniuConfig
    {
        public string AK { get; set; }
        public string SK { get; set; }
        public string Bucket { get; set; }
        public string QiniuBucketPath { get; set; }
    }
}
