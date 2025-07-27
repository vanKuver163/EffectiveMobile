using EffectiveMobile.Services;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementController(IAdvertisementService advertisementService) : ControllerBase
{

    public IActionResult UploadAdvertisements(IFormFile file)
    {
        return Ok();
    }
    
    public ActionResult<IEnumerable<string>> SearchAdvertisements(string location)
    {
        return Ok();
    }
}