using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Images
{
    public class ImageUploadRequestDto
    {
        [Required]
        [NotMapped]
        public IFormFile File { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
     
    }
}
