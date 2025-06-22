using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Utils
{
    internal static class UserUtil
    {
        public static bool isVip()
        {
            return Const.user != null && Const.user.vip - (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds) > 0;
        }
    }
}
