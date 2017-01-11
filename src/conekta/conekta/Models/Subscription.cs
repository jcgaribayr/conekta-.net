using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Conekta
{
    public class Subscription : Resource
	{
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        [JsonProperty("billing_cycle_start")]
        public int BillingCycleStart { get; set; }
        [JsonProperty("billing_cycle_end")]
        public int BillingCycleEnd { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("customer_id")]
        public string customer_id { get; set; }

		public Subscription ToClass(string json)
		{
			Subscription subscription = JsonConvert.DeserializeObject<Subscription>(json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

			return subscription;
		}

		public async Task<Subscription> Update(string data)
		{
			Subscription subscription = ToClass(await this.Update("/customers/" + this.customer_id + "/subscription", data));
			this.Id = subscription.Id;
			this.Status = subscription.Status;
			this.PlanId = subscription.PlanId;
			this.CardId = subscription.CardId;
			this.BillingCycleStart = subscription.BillingCycleStart;
			this.BillingCycleEnd = subscription.BillingCycleEnd;
            this.CreatedAt = subscription.CreatedAt;
			
            return this;
		}

		public async Task<Subscription> Pause()
		{
			Subscription subscription = ToClass(await this.Create("/customers/" + this.customer_id + "/subscription/pause", @"{}"));
			this.Status = subscription.Status;

            return this;
		}

		public async Task<Subscription> Resume()
		{
			Subscription subscription = ToClass(await this.Create("/customers/" + this.customer_id + "/subscription/resume", @"{}"));
			this.Status = subscription.Status;

            return this;
		}

		public async Task<Subscription> Cancel()
		{
			Subscription subscription = ToClass(await this.Create("/customers/" + this.customer_id + "/subscription/cancel", @"{}"));
			this.Status = subscription.Status;

            return this;
		}
	}
}

