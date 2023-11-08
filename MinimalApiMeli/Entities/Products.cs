namespace MinimalApiMeli.Entities;

public class Products
{
    public int id { get; set; }
    public string description { get; set; }
    public string categoryId { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string providerId { get; set; }
}
