using System.ComponentModel.DataAnnotations;

namespace CRUD_Application.Models
{
    public class Name {

        [Key]
        public int Id { get; set; }
        [Required]
        public String? FirstName { get; set; }
        [Required]
        public String? LastName { get; set; }
    }
}
