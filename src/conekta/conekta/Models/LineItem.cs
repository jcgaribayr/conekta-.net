using Newtonsoft.Json;

namespace Conekta
{
    public class LineItem
	{
        [JsonProperty("name")]
		public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("unit_price")]
        public int UnitPrice { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("sku")]
        public string SKU { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
	}
}
