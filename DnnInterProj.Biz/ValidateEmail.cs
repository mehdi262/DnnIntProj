using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DnnInterProj.Biz
{
    public static class ValidateEmail
    {
        public static bool IsValidEmail(this string email)
        {
            var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return !string.IsNullOrEmpty(email) && r.IsMatch(email);
        }
    }
}
