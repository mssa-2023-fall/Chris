using System.Numerics;
using System.Security.Cryptography;

namespace MssaExtension
{
    public enum StringFormat
    {
        Base64,
        Hex
    }

    public static class MssaExtensions
    {
        public static string GetSHAString(this FileInfo _file, StringFormat format = StringFormat.Hex)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                return format switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash).ToLower(),
                    _ => Convert.ToBase64String(fileHash)
                };

            }

        }

        public static float Median<T>(this IEnumerable<T> _intArr)
        {
            var sorted = _intArr.OrderBy(n => n).ToList();// lets arrange this input in sorted order so we can
            //pick out the middle item
            var middleItem = sorted.Count / 2;

            try
            {
                if (sorted.Count % 2 == 1)
                {
                    return Convert.ToSingle(sorted[middleItem]);
                }
                else
                {
                    var middleElementOne = Convert.ToSingle(sorted[middleItem]);
                    var middleElementTwo = Convert.ToSingle(sorted[middleItem - 1]);


                    return (middleElementOne + middleElementTwo) / 2;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("That type doesn't work.. ",ex);
            }
        }
    }
}