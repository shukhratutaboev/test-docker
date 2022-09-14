using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using test1.Models;

namespace test1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWebHostEnvironment _hostEnvironment;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostEnvironment = hostEnvironment;
    }

    [HttpPost("photo")]
    public async Task<IActionResult> Upload([FromForm] Media photo)
    {
        try
        {
            string folderName =  "/test-docker/static" + "/Images";
            if (!Directory.Exists(folderName)) {
                Directory.CreateDirectory(folderName);
            }
            var id = Guid.NewGuid();
            FileInfo fi = new FileInfo(photo.Photo!.FileName);
            var newFileName = id.ToString() + fi.Extension;
            var path = Path.Combine("", folderName + "/" + newFileName);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await photo.Photo.CopyToAsync(stream);
            }
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("photo")]
    public IActionResult Download()
    {
        try
        {
            string[] Documents = System.IO.Directory.GetFiles("/test-docker/static/Images/");
            return Ok(Documents);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
