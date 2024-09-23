using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Repository.QuestionRepository
{
    public interface IQuestionRepository
    {
        ICollection<Question> GetQuestions();
    }
}
