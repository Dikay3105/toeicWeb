using Microsoft.AspNetCore.Mvc;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Models;
using ToeicWeb.Server.ExamService.Repository.QuestionRepository;

namespace ToeicWeb.Server.ExamService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ExamDbContext _context;

        public QuestionController(IQuestionRepository questionRepository, ExamDbContext context)
        {
            _questionRepository = questionRepository;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Question>))]
        public IActionResult GetQuestions()
        {
            var question = _questionRepository.GetQuestions();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new
            {
                EC = 0,
                EM = "Get all questions success",
                DT = question
            });
        }
    }
}
