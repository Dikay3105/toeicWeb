using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Interfaces
{
    public interface IQuestionRepository
    {
        ICollection<Question> GetQuestions();
        Task<Question> GetQuestionById(int id);
        //Task DeleteQuestion(int id);
        //Task AddQuestion(int id);
    }
}
