using Microsoft.AspNetCore.Mvc;
using ToeicWeb.Server.ExamService.Services;

namespace ToeicWeb.Server.ExamService.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    private readonly TestService _examService;

    public ExamController(TestService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTests()
    {
        var tests = await _examService.GetTestsAsync();
        return Ok(tests);
    }

    // Add other CRUD operations as needed
}
