using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conekta
{
    public class Resource : ConektaObject, ICloneable
	{
		private Requestor requestor = new Requestor();
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("message")]
        public String Message { get; set; }
        [JsonProperty("MessageToPurchaser")]
        public String MessageToPurchaser { get; set; }
        [JsonProperty("code")]
        public String Code { get; set; }
        [JsonProperty("param")]
        public String Param { get; set; }

		public Resource() {}

		public async Task<string> Request(string method, string requestUri, string data)
		{
			return await requestor.Request(method, requestUri, data);
		}

		public async Task<string> Find(String requestUri, String id)
		{
			return await requestor.Request("GET", requestUri + "/" + id);
		}

		public async Task<string> Where(String requestUri, String data)
		{
			Dictionary<string, string> obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

			string list_params = "?";

			foreach (KeyValuePair<string, string> item in obj)
			{
				list_params += item.Key + "=" + item.Value + "&";
			}

			return await requestor.Request("GET", requestUri + list_params.Substring(0, list_params.Length - 1));
		}

		public async Task<string> Create(String requestUri, String data)
		{
			return await requestor.Request("POST", requestUri, data);
		}

		public async Task<string> Update(String requestUri, String data)
		{
			return await requestor.Request ("PUT", requestUri, data);
		}

		public async Task<string> Delete(String requestUri)
		{
			return await requestor.Request("DELETE", requestUri);
		}
	}
}
