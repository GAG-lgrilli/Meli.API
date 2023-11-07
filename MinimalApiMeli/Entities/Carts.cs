namespace MinimalApiMeli.Entities
{
    public class Carts
    {
        public int id { get; set; }

        public int userId { get; set; }

        public virtual User user { get; set; }

        public int productId { get; set; }

        public virtual Product product { get; set; }

        public DateTime lastModify { get; set; }

    }
}
