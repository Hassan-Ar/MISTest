using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.ViewModels
{
    public class ImageViewModel
    {

        [NotMapped]
      //  public IFormFile? File { get; set; } = null;

        [MaxLength(100)]
        public string? FileName { get; set; } = null;
    }
}
