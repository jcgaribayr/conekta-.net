using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conekta
{
    public class Requestor
	{
        public async Task<String> Request(String method, String requestUri, String data = "{}")
		{
            string response = string.Empty;

            try
            {
                HttpClient httpClient = new HttpClient();

                HttpMethod httMethod = new HttpMethod(method);
                Uri uri = new Uri(Api.BaseUri + requestUri);

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httMethod, uri);
                httpRequestMessage.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(Api.ApiKey)) + ":");
                httpRequestMessage.Headers.Add("Accept", "application/vnd.conekta-v" + Api.Version + "+json");
                httpRequestMessage.Headers.Add("Accept-Language", Api.ApiKey);
                httpRequestMessage.Headers.Add("User-Agent", "Conekta/v1 DotNetBindings/" + Api.Version);

                if (httMethod.Method.Equals("POST")
                    || httMethod.Method.Equals("PUT"))
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(data);
                    Stream stream = new MemoryStream(bytes);
                    HttpContent httpContent = new StreamContent(stream);
                    httpRequestMessage.Content = httpContent;

                    httpContent.Headers.Add("Content-Length", bytes.Length.ToString());
                    httpContent.Headers.Add("Content-Type", "application/json");
                }

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                response = await httpResponseMessage.Content.ReadAsStringAsync();
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpReqEx)
            {
                JObject obj = JsonConvert.DeserializeObject<JObject>(response, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                ConektaException conektaEx = new ConektaException(obj.GetValue("message_to_purchaser").ToString());
                conektaEx.MessageToPurchaser = obj.GetValue("message_to_purchaser").ToString();
                conektaEx.Message = obj.GetValue("message").ToString();
                conektaEx.Type = obj.GetValue("type").ToString();

                throw conektaEx;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return "";
            }

            return response;
        }
	}

}
