using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.Extensions
{
    public static class EncodeExtensions
    {
        public static string ToBase64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string ToBase64Decode(this string base64EncodedData)
        {
            if (!string.IsNullOrEmpty(base64EncodedData))
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            else
            {
                return "";
            }
            
        }
    }
}
