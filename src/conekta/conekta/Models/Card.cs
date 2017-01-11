using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Conekta
{
    public class Card : Resource
	{
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("last4")]
        public string Last4 { get; set; }
        [JsonProperty("exp_month")]
        public string ExpirationMonth { get; set; }
        [JsonProperty("exp_year")]
        public string ExpirationYear { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        public Card ToClass(string json)
		{
			Card card = JsonConvert.DeserializeObject<Card> (json, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

            return card;
		}

		public async Task<Card> Update(string data)
		{
			Card card = ToClass(await this.Update("/customers/" + this.CustomerId + "/cards/" + this.Id, data));
			this.Id = card.Id;
			this.Name = card.Name;
			this.Brand = card.Brand;
			this.Last4 = card.Last4;
			this.ExpirationMonth = card.ExpirationMonth;
			this.ExpirationYear = card.ExpirationYear;
			this.CreatedAt = card.CreatedAt;
			this.CustomerId = card.CustomerId;

            return this;
		}

		public async Task<Card> delete ()
		{
			Card card = ToClass(await this.Delete("/customers/" + this.CustomerId + "/cards/" + this.Id));
			int index = Customer.Cards.IndexOf (this);
			Customer.Cards.RemoveAt (index);

			return card;
		}
	}
}