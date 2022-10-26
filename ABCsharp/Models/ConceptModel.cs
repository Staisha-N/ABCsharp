using System.ComponentModel.DataAnnotations;

namespace ABCsharp.Models
{
    public class ConceptModel
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Enter a title for this concept.")]
        public string? title { get; set; }
        [Required(ErrorMessage = "Enter a description of this concept.")]
        public string? description { get; set; }
        [Required(ErrorMessage = "Enter details for this concept.")]
        public string? details { get; set; }
    }
}
