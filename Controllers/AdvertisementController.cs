using EffectiveMobile.Services;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementController(IAdvertisementService advertisementService) : ControllerBase
{

    [HttpPost("unload")]
    public IActionResult UploadAdvertisements(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Требуется файл!");

        try
        {
            using var stream = new StreamReader(file.OpenReadStream());
            advertisementService.LoadAdvertisements(stream);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка сервера: {ex.Message}");
        }
    }
    
    [HttpGet("search")]
    public ActionResult<IEnumerable<string>> SearchAdvertisements(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            return BadRequest("Требуется локация!");

        try
        {
            var ads = advertisementService.GetAdvertisements(location);
            return Ok(ads);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка сервера: {ex.Message}");
        }
    }
}