using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Conekta
{
    public class Charge : Resource
	{
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("monthly_installments")]
        public int MonthlyInstallments { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("cash")]
        public Cash Cash { get; set; }
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
        [JsonProperty("bank")]
        public Bank Bank { get; set; }
        [JsonProperty("details")]
        public Details Details { get; set; }

		public Charge ToClass(string json)
		{
			Charge charge = JsonConvert.DeserializeObject<Charge> (json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

            return charge;
		}

		public async Task<Charge> Create(string data)
		{
			string charge = await this.Create("/charges", data);

            return this.ToClass(charge);
		}

		public async Task<Charge> Find(string id)
		{
			string charge = await this.Find("/charges", id);

            return this.ToClass(charge);
		}

		public async Task<Charge[]> Where(string data = @"{}")
		{
			string result = await this.Where("/charges", data);

			Regex pattern = new Regex("\"object\":", RegexOptions.Multiline | RegexOptions.IgnoreCase);
			result = pattern.Replace(result, "\"_object\":");

			Charge[] charges = JsonConvert.DeserializeObject<Charge[]>(result, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

			return charges;
		}

		public async Task<Charge> Capture()
		{
			return this.ToClass(await this.Request("POST", "/charges/" + this.Id + "/capture", @"{}"));
		}

		public async Task<Charge> Refund(int amount = 0)
		{
			if (amount > 0)
            {
				return this.ToClass(await this.Request("POST", "/charges/" + this.Id + "/refund", @"{""amount"": " + amount.ToString() + "}"));
			}
            else
            {
				return this.ToClass(await this.Request("POST", "/charges/" + this.Id + "/refund", @"{}"));
			}
		}
	}
}
