namespace ERS.Models
{
    public class ProductTemplate
    {
        public int Id { get; set; }

        public string TemplateName { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
