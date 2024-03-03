using System.ComponentModel.DataAnnotations;

namespace ITStepShop.Models
{
    public class Usage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
