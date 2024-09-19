using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Interfaces
{
    public interface IQuestionRepository
    {
        ICollection<Question> GetQuestions();
    }
}
