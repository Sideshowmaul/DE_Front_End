using DE_Front_End.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DE_Front_End.Clients
{
    public class HttpClient
    {
        public string Get(HttpModel model)
        {
            var result = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(model.Uri);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public string Post(HttpModel model)
        {
            var result = string.Empty;
            var bytes = Encoding.UTF8.GetBytes(model.Serialize());
            var request = (HttpWebRequest)WebRequest.Create(model.Uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;

            using(var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            result = Get(model);
            return result;
        }

        public string Put(HttpModel model)
        {
            var result = string.Empty;
            var bytes = Encoding.UTF8.GetBytes(model.Serialize());
            var request = (HttpWebRequest)WebRequest.Create(model.Uri);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;

            using (var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                throw;
            }
            result = Get(model);
            return result;
        }
    }
}
