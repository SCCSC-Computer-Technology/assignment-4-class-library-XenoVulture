using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SearchLibrary2
{
    public static class StringCheck
    {
        public static int ContainsValidData(this string str) // public static int ContainsValidData(this string? str) 
                                                             // NEEDS C# 8.0+ to allow for null (the '?' part), filter out nulls before they get here.
                                                             // IsNull left in so if this is updated it is ready to go.
        {
            int x = 0;
            char ch;

            if (!string.IsNullOrEmpty(str)) // If the string is not just null or empty
            {
                ch = str[0]; // Get the first character of the string

                if (char.IsLetter(ch)) // Allows for letters or spaces.
                {
                    Regex r = new Regex("^[A-Za-z ]+$");

                    if (r.IsMatch(str)) // Compare input against 
                    {
                        x = 1; // Only contains letters or spaces.
                    }
                    else // If this contains anything not a letter of a space, return the int code for "started with letter, but had no letter/space chars.
                    {
                        return -1; // Means started with letter, but contains chars that are not letters.
                    }
                }
                else if (char.IsDigit(ch)) // || char.IsWhiteSpace(ch) Allowing for spaces here shouldn't be needed. Include in error message.
                {
                    // This is basically decimal.TryParse(), but I thought this might be expandable to clearly explain invalid input.

                    Regex r = new Regex("^[0-9]*([.,][0-9]*)?$"); // Allows for only digits, "." and ","

                    if (r.IsMatch(str)) // Check each char to make sure it is a digit.
                    {
                        x = 2; // Only contains numbers, ',' or '.'.
                    }
                    else // If it contains anything other than a digit
                    {
                        return -2; // Means started with digit, but contains chars that are not digits.
                    }
                }
                else // String does not start with a letter or digit.
                {
                    return 0;
                }
            }
            else // String is either null, or white space
            {

                return 0;
            }

            return x;
        }
    }
}
