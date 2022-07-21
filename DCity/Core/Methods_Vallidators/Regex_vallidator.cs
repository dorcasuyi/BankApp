using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DCity.Core.Methods_Vallidators
{
    public class Regex_vallidator
    {
        public static bool CheckEmail(string email)
        {
            string strRegex = @"^[a-z]+[0-9a-zA-Z_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return PerformRegEx(strRegex, email);
        }
        public static bool CheckPoneNumber(string phoneNumber)
        {
            string strRegex = @"^[0-9]{11}";
            return PerformRegEx(strRegex, phoneNumber);
        }
        public static bool CheckName(string name)
        {
            string strRegex = @"^[A-Z]";
            return PerformRegEx(strRegex, name);
        }
        public static bool CheckPassword(string password)
        {
            string strRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%#?&])[A-Za-z\d@$!%*#?&]{6,}$";
            return PerformRegEx(strRegex, password);
        }
        private static bool PerformRegEx(string pattern, string value)
        {
            Regex re = new Regex(pattern);

            if (re.IsMatch(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

