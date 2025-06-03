using System.ComponentModel.DataAnnotations;

namespace Week3_MVCFlowerShop.Models
{
    public class Flower
    {
        [Key]
        public int FlowerID { get; set; }
        public string? FlowerName { get; set; }
        public string? FlowerType { get; set; }
        public DateTime FlowerProducedDate { get; set; }
        public decimal FlowerPrice { get; set; }
    }
}
