using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mitarbeitershop_Hydro.Models
{
    public class SubCategory
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image {  get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        public string CategoryId { get; set; }
        
    }
}
