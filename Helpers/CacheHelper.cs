using System.Text;
using Newtonsoft.Json;

namespace Core.Helpers;

public class CacheHelper
{
    public static byte[] Encode(object value)
    {
        if (null == value)
        {
            return [];
        }

        var serializedPoco = JsonConvert.SerializeObject(value);
        return Encoding.UTF8.GetBytes(serializedPoco);
    }

    public static T? Decode<T>(byte[] value)
    {
        if (null == value)
        {
            return default;
        }

        var serializedPoco = Encoding.UTF8.GetString(value);
        return (T)JsonConvert.DeserializeObject(serializedPoco, typeof(T));
    }
}