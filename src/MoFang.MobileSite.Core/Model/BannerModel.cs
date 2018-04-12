using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Core.Model
{
    public class BannerModel : BaseModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public int Seq { get; set; }
    }
}
