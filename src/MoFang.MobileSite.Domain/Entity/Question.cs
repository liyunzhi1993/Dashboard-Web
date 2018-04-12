using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public string Correct { get; set; }
        public string Answers { get; set; }
        public sbyte IsValid { get; set; }
    }
}
