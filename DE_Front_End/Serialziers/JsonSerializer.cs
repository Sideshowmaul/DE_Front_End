using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DE_Front_End.Serialziers
{
    public class JsonSerializer
    {
        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
