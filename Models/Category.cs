namespace CialMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Expert>? Experts { get; set; }  
    }
}
