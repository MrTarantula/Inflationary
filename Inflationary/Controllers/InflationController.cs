using Inflationary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PhoneticMatching;

namespace Inflationary.Controllers;

[ApiController]
[Route("[controller]")]
public class InflationController : ControllerBase
{
    private readonly ILogger<InflationController> _logger;
    private readonly TranslationService _translationService;

    public InflationController(ILogger<InflationController> logger, TranslationService translationService)
    {
        _logger = logger;
        _translationService = translationService;
    }

    [HttpGet("inflate")]
    public Translation Inflate(string input) => _translationService.Translate(input);
}
