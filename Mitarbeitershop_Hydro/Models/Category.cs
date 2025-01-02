using System.ComponentModel.DataAnnotations;

namespace Mitarbeitershop_Hydro.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image {  get; set; }
    }
}
