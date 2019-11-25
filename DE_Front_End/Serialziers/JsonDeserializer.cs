using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DE_Front_End.Serialziers
{
    public class JsonDeserializer<T> where T : class
    {
        public static List<T> DeserializeObject(string data)
        {
            return JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
}
