using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Poker.Utils
{
    internal static class StringUtil
    {

        public static bool check(string username, string password)
        {
            /*return !(username.contains(" ") || password.contains(" ") || username.equals("") || password.equals("") || username.contains(",") || username.contains("&")
                    || username.contains("?") || password.contains("&") || password.contains("?") || username.contains("=") || password.contains("=") || username.contains("/")
                    || password.contains("/") || username.contains("\\") || password.contains("\\"));*/
            return !(username.Contains(" ") || password.Contains(" ") || username.Equals("") || password.Equals("") || username.Length >= 50 || password.Length >= 50);
        }

        public static bool check(string password)
        {
            return !(password.Contains(" ") || password.Equals("") || password.Length >= 20);
        }

        public static bool checkUsername(string username)
        {
            return !(username.Contains(" ") || username.Equals("") || username.Length >= 15);
        }

        public static bool isEmail(string str)
        {
            bool isEmail = false;
            string expr = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";

            if (Regex.IsMatch(str, expr))
            {
                isEmail = true;
            }
            if (isEmail)
            {
                return str.EndsWith("@126.com") || str.EndsWith("@163.com") || str.EndsWith("@qq.com") || str.EndsWith("@sina.com") ||
                        str.EndsWith("@sina.cn") || str.EndsWith("@outlook.com") || str.EndsWith("@gmail.com") || str.EndsWith("@mjczy.top");
            }
            return false;
        }
    }
}
