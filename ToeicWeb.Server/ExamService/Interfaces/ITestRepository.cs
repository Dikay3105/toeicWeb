using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests();
        Task<Test> GetTestById(int id);
        Task<ICollection<Part>> GetPartOfQuestion(int id);
    }
}
