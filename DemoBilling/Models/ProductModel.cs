namespace DemoBilling.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> Quantities { get; set; }
    }
}
