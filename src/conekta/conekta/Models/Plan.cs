using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Conekta
{
    public class Plan : Resource
	{
        [JsonProperty("id")]
		public String Id { get; set; }
        [JsonProperty("name")]
		public String Name { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public String Currency { get; set; }
        [JsonProperty("interval")]
        public String Interval { get; set; }
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
        [JsonProperty("trial_period_days")]
        public int TrialPeriodDays { get; set; }
        [JsonProperty("expiry_count")]
        public int ExpiryCount { get; set; }

		public Plan ToClass(string json)
		{
            Plan plan = JsonConvert.DeserializeObject<Plan>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return plan;
		}

		public async Task<Plan> Create(string data)
		{
			return this.ToClass(await this.Create("/plans", data));
		}

		public async Task<Plan> Find(string id)
		{
			return this.ToClass(await this.Find("/plans/", id));
		}

		public async Task<Plan> Update(string data)
		{
			Plan plan = ToClass(await this.Update("/plans/" + this.Id, data));
			this.Id = plan.Id;
			this.Name = plan.Name;
			this.Amount = plan.Amount;

            return this;
		}

		public async Task<Plan> Delete()
		{
			return ToClass(await this.Delete("/plans/" + this.Id));
		}
	}
}