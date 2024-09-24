using Microsoft.AspNetCore.Mvc;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Interfaces;
using ToeicWeb.Server.ExamService.Models;

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

        //Get all question
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

        // Get question by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestionById(int id)
        {
            var question = await _questionRepository.GetQuestionById(id);
            if (question == null)
            {
                return NotFound(new
                {
                    EC = -1,  // Error Code
                    EM = "No data found",
                    DT = "",   // Data (can be an empty string or message)

                }); // Return 404 if user not found
            }

            return Ok(new
            {
                EC = 0,  // Error Code
                EM = "Get question by id success",
                DT = question  // Data (can be an empty string or message)

            }); // Return the found user
        }

        // API endpoint để lấy câu trả lời của câu hỏi theo id
        [HttpGet("question/{id}")]
        public async Task<IActionResult> GetAnswersOfQuestion(int id)
        {
            // Gọi phương thức trong repository để lấy câu trả lời
            var question = await _questionRepository.GetQuestionById(id);
            if (question == null)
            {
                return NotFound(new
                {
                    EC = -1,
                    EM = "No question found for the given question ID."
                });
            }

            var answers = await _questionRepository.GetAnswerOfQuestion(id);

            // Kiểm tra nếu không có câu trả lời nào
            if (answers == null || !answers.Any())
            {
                return NotFound(new
                {
                    EC = -1,
                    EM = "No answers found for the given question ID."
                });
            }

            // Trả về danh sách câu trả lời
            return Ok(new
            {
                EC = 0,
                EM = "Get answer of questionId=" + id + " success",
                DT = new
                {
                    question = question,
                    answers = answers
                }
            });
        }

    }
}
