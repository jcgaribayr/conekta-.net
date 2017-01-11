using Newtonsoft.Json;

namespace Conekta
{
    public class BillingAddress
	{
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }
        [JsonProperty("street3")]
        public string Street3 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip")]
        public string Zip { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
	}
}
