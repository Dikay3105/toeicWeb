using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Repository.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamDbContext _context;

        public QuestionRepository(ExamDbContext context)
        {
            _context = context;
        }

        public ICollection<Question> GetQuestions()
        {
            return _context.Questions.ToList();
        }
    }
}
