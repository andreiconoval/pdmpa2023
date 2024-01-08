using Microsoft.AspNetCore.Mvc;
using TeammateApi.Data;

namespace TeammateApi.Features.UserProfile;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly ILogger<UserProfileController> _logger;
    private readonly IUserProfileService _profileService;

    public UserProfileController(ILogger<UserProfileController> logger, IUserProfileService profileService)
    {
        _logger = logger;
        _profileService = profileService;
    }

    [HttpGet("GetWeatherForecasts")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55)
        }).ToArray();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserProfileEntity userProfile)
    {
        await _profileService.UpdateAsync(userProfile);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<UserProfileEntity>> Get([FromQuery] string userProfile)
    {
        var profile = await _profileService.GetAsync(userProfile);
        return Ok(profile);
    }
}