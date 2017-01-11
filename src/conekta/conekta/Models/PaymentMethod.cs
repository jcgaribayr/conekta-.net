using Newtonsoft.Json;
using System;

namespace Conekta
{
    public class PaymentMethod
	{
        [JsonProperty("expires_at")]
        public Int64 ExpiresAt { get; set; }
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("_object")]
        public String Object { get; set; }

        /*Oxxo Payment*/
        [JsonProperty("barcode")]
        public String Barcode { get; set; }
        [JsonProperty("barcode_url")]
        public String BarcodeUrl { get; set; }
        [JsonProperty("store_name")]
        public String StoreName { get; set; }

        /*Spei Payment*/
        [JsonProperty("clabe")]
        public String CLABE { get; set; }
        [JsonProperty("bank")]
        public String Bank { get; set; }
        [JsonProperty("issuing_account_holder")]
        public String IssuingAccountHolder { get; set; }
        [JsonProperty("issuing_account_tax_id")]
        public String IssuingAccountTaxId { get; set; }
        [JsonProperty("issuing_account_bank")]
        public String IssuingAccountBank { get; set; }
        [JsonProperty("issuing_account_number")]
        public String IssuingAccountNumber { get; set; }
        [JsonProperty("receiving_account_holder")]
        public String ReceivingAccountHolder { get; set; }
        [JsonProperty("receiving_account_tax_id")]
        public String ReceivingAccountTaxId { get; set; }
        [JsonProperty("receiving_account_number")]
        public String ReceivingAccountNumber { get; set; }
        [JsonProperty("receiving_account_bank")]
        public String ReceivingAccountBank { get; set; }
        [JsonProperty("reference_number")]
        public String ReferenceNumber { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("tracking_code")]
        public String TrackingCode { get; set; }

        /*Credit Card Payment*/
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("exp_month")]
        public String ExpirationMonth { get; set; }
        [JsonProperty("exp_year")]
        public String ExpirationYear { get; set; }
        [JsonProperty("auth_code")]
        public String AuthCode { get; set; }
        [JsonProperty("normalized_device_fingerprint")]
        public String NormalizedDeviceFingerprint { get; set; }
        [JsonProperty("last4")]
        public String Last4 { get; set; }
        [JsonProperty("brand")]
        public String Brand { get; set; }
        [JsonProperty("issuer")]
        public String Issuer { get; set; }
        [JsonProperty("account_type")]
        public String AccountType { get; set; }
        [JsonProperty("country")]
        public String Country { get; set; }
        [JsonProperty("fraud_score")]
        public float FraudScore { get; set; }

        /*Banorte payment*/
        [JsonProperty("service_name")]
        public String ServiceName { get; set; }
        [JsonProperty("service_number")]
        public String ServiceNumber { get; set; }
        [JsonProperty("reference")]
        public String Reference { get; set; }
	}
}

