namespace MinimalApiMeli.Entities;

public class Products
{
    public Products() {

        Providers_Products = new HashSet<Provider>();

        Category_Products = new HashSet<Category>();
    }
    
    public int id { get; set; }
    public string description { get; set; }
    public string categoryId { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string providerId { get; set; }

    public virtual ICollection<Provider> Providers_Products { get; set; }
    public virtual ICollection<Category> Category_Products { get; set; }

}
