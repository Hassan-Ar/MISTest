using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.RealestateApp.App1.ViewModels
{
    public class ImageViewModel
    {

        [NotMapped]
        public IFormFile? File { get; set; } = null;

        [MaxLength(100)]
        public string? FileName { get; set; } = null;
    }
}
