namespace ScrappingApp
{
    public class Product
    {
        public int sold { get; set; }
        public bool listOnMarket { get; set; }
        public bool is_visible { get; set; }
        public double sold_value { get; set; }
        public string description { get; set; }
        public double weight { get; set; }
        public int merchant { get; set; }
        public List<Variant> variants { get; set; }
        public Store store { get; set; }
        public int priority { get; set; }
        public double? price { get; set; }
        public Meta meta { get; set; }
        public double? qty { get; set; }
        public int __v { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string sku { get; set; }
        public string market_status { get; set; }
        public string display_image { get; set; }
        public string slug { get; set; }
        public List<object> gallery { get; set; }
        public object ts { get; set; }
        public List<StoreCategory> store_categories { get; set; }
        public string _id { get; set; }
        public bool? is_christmas { get; set; }
        public string alt_category { get; set; }
        public string coupon_code { get; set; }
        public bool? is_gift { get; set; }
        public string coupon_type { get; set; }
        public bool? is_blackfriday { get; set; }
        public int? discount_amount { get; set; }
        public long? coupon_validity_start_date { get; set; }
        public long? coupon_validity_end_date { get; set; }
    }


}
