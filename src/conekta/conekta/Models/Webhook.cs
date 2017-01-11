using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Conekta
{
	public class Webhook : Resource
	{
        [JsonProperty("id")]
		public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("events")]
        public string[] Events { get; set; }

		public Webhook ToClass(string json)
		{
			Webhook webhook = JsonConvert.DeserializeObject<Webhook>(json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

			return webhook;
		}

		public async Task<Webhook> Find(string id)
		{
			string response = await this.Find("/webhooks", id);

            return this.ToClass(response);
		}

		public async Task<Webhook> Create(string data)
		{
			Webhook webhook = this.ToClass(await this.Create("/webhooks", data));

            return webhook;
		}

		public async Task<Webhook> Update(string data)
		{
			Webhook webhook = this.ToClass(await this.Update ("/webhooks/" + this.Id, data));
			this.Id = webhook.Id;
			this.Url = webhook.Url;
			this.Events = webhook.Events;

            return this;
		}
	}
}

