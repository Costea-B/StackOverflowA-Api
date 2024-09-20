using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public partial class InputValidator
    {
        /*
            * (?=.*[a-z]) = at least one lower case char
            * (?=.*[A-Z]) = at least one upper case char
            * (?=.*\d) = at least one digit
            * [a-zA-Z\d] = at least one lower/upper/digit from 8 to unlimited char
            */
        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", RegexOptions.Compiled, 2000)]
        private static partial Regex PassRegex();

        public static bool IsPasswordValid(string password)
        {
            return PassRegex().IsMatch(password);
        }
        public static bool IsEmailValid(string email)
        {
            return MailAddress.TryCreate(email, out _);
        }
    }
}
