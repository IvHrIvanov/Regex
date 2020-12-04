using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexWhitDigits = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            string text = Console.ReadLine();
            Regex regex = new Regex(regexWhitDigits);
            MatchCollection emails = regex.Matches(text);

            foreach (Match item in emails)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
