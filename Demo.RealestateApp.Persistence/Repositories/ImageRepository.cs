using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Persistence.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly RealestateAppDbContext _context;

        public ImageRepository(RealestateAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Image> UploadImage(Image image)
        {
            var LocalFile = Path.Combine("", "Images",
              $"{image.FileName}{image.FileExtension}");

            using var filestream = new FileStream(LocalFile, FileMode.Create);
            await image.File.CopyToAsync(filestream);
            //
            //  https://LocalHost:1234/Images/ImageName.jpg

            string path = $"{_contextAccessor.HttpContext.Request.Scheme}" +
                $"://{_contextAccessor.HttpContext.Request.Host}" +
                $"{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = path;

            // Add To Db
            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
