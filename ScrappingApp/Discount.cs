namespace ScrappingApp
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Discount
    {
        public double? original_price { get; set; }
        public bool has_discount { get; set; }
    }


}
