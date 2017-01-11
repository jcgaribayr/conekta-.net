using Newtonsoft.Json;
using System.Collections.Generic;

namespace Conekta
{
    public class Details
	{
        [JsonProperty("name")]
		public string Name { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }
        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }
        [JsonProperty("shipment")]
        public ShippingAddress Shipment { get; set; }
	}
}
