using CialMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace CialMVC.ViewModels.ExpertVM
{
    public class ExpertListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Category? Category {  get; set; }
    }
}
