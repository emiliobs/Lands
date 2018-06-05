namespace Lands.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    public class RegexUtilities
    {
       public static bool IsValidEmail(string email)
        {
            var expresion = "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }
        }
    }
}
