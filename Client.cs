using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpClientFramework.Entities;
using Newtonsoft.Json;

namespace HttpClientFramework
{
    public class Client
    {
        public Response Get<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return new Response(true, JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result), response.StatusCode, null);
                    }
                    return new Response(false, null, response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public Response Post(Uri uri, object payload)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")).Result)
                {
                    return CreateResponse(response);
                }
            }
        }

        public Response Put(Uri uri, object payload)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.PutAsync(uri, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")).Result)
                {
                    return CreateResponse(response);
                }
            }
        }

        public Response Delete(Uri uri, object payload)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.DeleteAsync(uri).Result)
                {
                    return CreateResponse(response);
                }
            }
        }

        private static Response CreateResponse(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                return new Response(true, null, message.StatusCode, null);
            }
            return new Response(false, null, message.StatusCode, message.Content.ReadAsStringAsync().Result);
        }
    }
}
