using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Helpers
{
    public static class TextHelper
    {
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Shorten string and add an "after string"
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="length">Max length for string</param>
        /// <param name="afterString">String to be added after shortened string</param>
        /// <returns>Shortened string</returns>
        public static string ShortenString(string s, int length, string afterString)
        {
            string shortenString = s;
            if (s.Length > length)
            {
                shortenString = s.Remove(length) + afterString;
            }

            return shortenString;
        }

        /// <summary>
        /// Shorten string
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="length">Max length for string</param>
        /// <returns>Shortened string</returns>
        public static string ShortenString(string s, int length)
        {
            string shortenString = s;
            if (s.Length > length)
                shortenString = s.Remove(length);

            return shortenString;
        }

        /// <summary>
        /// Reverse the order of string
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Reversed string</returns>
        public static string ReverseString(this string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }

            return new string(charArray);
        }

        public static string TrimToLastWord(this string inputString, int newLength)
        {
            if (newLength > inputString.Length)
                return inputString;

            var cutOffPoint = inputString.IndexOf(" ", newLength - 1, StringComparison.Ordinal);
            if (cutOffPoint <= 0)
                cutOffPoint = inputString.Length;

            return inputString.Substring(0, cutOffPoint) + "...";
        }

        public static string GetFirstWord(this string input)
        {
            return input.Split(' ').First();
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string Slugify(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non valid chars          
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes

            return str;
        }
    }
}
