using System.ComponentModel.DataAnnotations;

namespace CialMVC.ViewModels.ExpertVM
{
    public class ExpertUpdateVM
    {
        [Required, MaxLength(32), MinLength(3)]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int? CategoryId { get; set; }

    }
}
