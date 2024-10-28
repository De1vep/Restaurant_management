namespace PR.Models
{
    public class CartItem
    {

        public string? Name { get; set; }
        public string? Img { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Quantity * Price;

    }
}
