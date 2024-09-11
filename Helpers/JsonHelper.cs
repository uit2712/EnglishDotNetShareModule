using Newtonsoft.Json;

namespace Core.Helpers;

public class JsonHelper
{
    public static string Encode(object value)
    {
        return JsonConvert.SerializeObject(value);
    }
}