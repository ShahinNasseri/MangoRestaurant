using Newtonsoft.Json;

namespace Mango.Web.Helpers
{
    public static class JsonHelper<T>
    {

        public static T DeserializeObject(object obj)
        {
            return JsonConvert.DeserializeObject<T>(Convert.ToString(obj));
        }
    }
}
