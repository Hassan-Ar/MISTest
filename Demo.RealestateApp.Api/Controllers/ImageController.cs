using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.RealestateApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        [HttpPost(Name = "AddImage")]
        public async Task<ActionResult<ImageUploadRequestDto>> Create([FromForm] ImageUploadRequestDto uploadImage)
        {
            return Ok(uploadImage);
        }


    }
}
