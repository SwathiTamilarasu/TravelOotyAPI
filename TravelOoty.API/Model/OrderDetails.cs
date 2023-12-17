using System.Text.Json.Serialization;

namespace TravelOoty.API.Model
{
    public class OrderDetails
    {
      // [JsonPropertyName("customer_details")]
        public CustomerDetails customer_details { get; set; }
        // [JsonPropertyName("order_meta")]
          public OrderMeta order_meta { get; set; }
        //  [JsonPropertyName("order_id")]
        public string order_id { get; set; }
        // [JsonPropertyName("order_amount")]
        public decimal order_amount { get; set; }
        // [JsonPropertyName("order_currency")]
        public string order_currency { get; set; }

    }

    public class CustomerDetails
    {
      // [JsonPropertyName("customer_id")]
        public string customer_id { get; set; }
      // [JsonPropertyName("customer_email")]
        public string customer_email { get; set; }
      // [JsonPropertyName("customer_phone")]
        public string customer_phone { get; set; }

    }
    public class OrderMeta
    {
      //  [JsonPropertyName("return_url")]
        public string return_url { get;set; }
       // [JsonPropertyName("notify_url")]
        public string notify_url { get; set; }
    }
}
