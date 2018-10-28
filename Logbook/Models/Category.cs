using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.Models
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}