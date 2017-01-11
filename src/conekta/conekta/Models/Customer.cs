using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conekta
{
    public class Customer : Resource
	{
        [JsonProperty("id")]
		public string Id { get; set; }
        [JsonProperty("name")]
		public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("cards")]
        public List<Card> Cards { get; set; }
        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
        [JsonProperty("plan")]
        public string Plan { get; set; }
        [JsonProperty("logged_in")]
        public bool LoggedIn { get; set; }
        [JsonProperty("successful_purchases")]
        public int SuccessfulPurchases { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
        [JsonProperty("offline_payments")]
        public int OfflinePayments { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }

		public Customer ToClass(string json)
		{
            Customer customer = JsonConvert.DeserializeObject<Customer>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return customer;
		}

		public Card ToCard(string json)
		{
			Card card = JsonConvert.DeserializeObject<Card>(json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});
			card.Customer = this;
            this.Cards.Add(card);

            return card;
		}

		public Subscription ToSubscription(string json)
		{
			Subscription subscription = JsonConvert.DeserializeObject<Subscription>(json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});
			this.Subscription = subscription;
			this.Plan = subscription.PlanId;

            return subscription;
		}

		public async Task<Customer> Create(string data)
		{
			return this.ToClass(await this.Create("/customers", data));
		}

		public async Task<Customer> Find(string id)
		{
			return this.ToClass(await this.Find("/customers", id));
		}

		public async Task<Customer> Update(string data)
		{
			return this.ToClass(await this.Update("/customers/" + this.Id, data));
		}

		public async Task<Customer> Delete()
		{
			return this.ToClass(await this.Delete("/customers/" + this.Id));
		}

		public async Task<Card> CreateCard(string data)
		{
			return this.ToCard(await this.Create("/customers/" + this.Id + "/cards", data));
		}

		public async Task<Subscription> CreateSubscription(string data)
		{
			return this.ToSubscription(await this.Create("/customers/" + this.Id + "/subscription", data));
		}
	}
}

