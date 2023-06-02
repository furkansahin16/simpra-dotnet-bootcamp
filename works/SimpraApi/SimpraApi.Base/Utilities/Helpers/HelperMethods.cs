using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace SimpraApi.Base;
public static class HelperMethods
{
    public static string NormalizeString(this string str)
    {
        str = str.ToLower().Trim();
        str = char.ToUpper(str[0]) + str.Substring(1);
        return str;
    }

    public static string Format(this string str, params string[] args)
    {
        return String.Format(str, args);
    }

    public static bool CheckIfOlderThan18(this string date)
    {
        DateTime dateOfBirth;
        if (DateTime.TryParse(date, out dateOfBirth))
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
        return false;
    }

    public static bool IsValidDate(this string date)
    {
        return DateTime.TryParse(date, out _);
    }

    public static bool IsValidUrl(this string url)
    {
        return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _);
    }

    public static bool IsValidGuid(this string id)
    {
        return Guid.TryParse(id, out _);
    }

    public static byte[] CreatePasswordHash(this string password)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static bool VerifyPassword(this string password, byte[] passwordHash)
    {
        using (SHA256 hash = SHA256.Create())
        {
            var computedHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            bool value =  computedHash.SequenceEqual(passwordHash);
            return value;
        }
    }

    public static string ToJson(this object instance)
    {
        return JsonConvert.SerializeObject(instance);
    }
}
