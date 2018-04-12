using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFang.MobileSite.Domain.Consts
{
    public sealed class RedisKeys
    {
        public static string GetTokenCacheKey(string token)
        {
            return $"Token:{token}";
        }
        public const string User = "User";
    }
}
