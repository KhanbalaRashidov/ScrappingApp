namespace ScrappingApp
{
    public class Meta
    {
        public List<ShippingFee> shipping_fees { get; set; }
        public string description { get; set; }
        public int version { get; set; }
        public List<Option> options { get; set; }
        public Discount discount { get; set; }
        public List<Gallery> gallery { get; set; }
    }


}
