using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Article
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string OriginUrl { get; set; }
        public DateTime Created { get; set; }
        public string Banner { get; set; }
        public string Photos { get; set; }
        public sbyte IsValid { get; set; }
        public string Description { get; set; }
    }
}
