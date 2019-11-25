using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DE_Front_End.Models
{
    public abstract class HttpModel
    {
        [JsonIgnore]
        public string Uri { get; private set; }

        protected HttpModel(string uri)
        {
            Uri = uri;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
