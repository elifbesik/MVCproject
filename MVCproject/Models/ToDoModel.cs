using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MVCproject.Models
{
    public class ToDoModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsComplete { get; set; }
    
    }

}
