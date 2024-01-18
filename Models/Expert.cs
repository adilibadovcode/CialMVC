using System.ComponentModel.DataAnnotations;

namespace CialMVC.Models
{
    public class Expert
    {
        public int Id { get; set; }
        [Required,MaxLength(32),MinLength(3)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public Category? Categories { get; set; }
    }
}
