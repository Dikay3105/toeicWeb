using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Interfaces;
using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamDbContext _context;

        public QuestionRepository(ExamDbContext context)
        {
            _context = context;
        }

        // Get all questions
        public ICollection<Question> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<ICollection<Answer>> GetAnswerOfQuestion(int id)
        {
            var answers = await _context.Answers
                                        .Where(a => a.QuestionID == id)
                                        .ToListAsync();

            return answers;
        }

    }
}
