using Newtonsoft.Json;
using System;

namespace Conekta
{
    public class Bank
	{
        [JsonProperty("type")]
		public String Type { get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
	}
}