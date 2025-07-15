using DataAccessLayer.DTOs.response;

namespace Services.Impl
{
    public interface F_QImpl
    {
        Task<IEnumerable<QuestionRes>> GetAllQuestionsAsync();
        Task<QuestionRes?> GetQuestionByIdAsync(int id);
   }
}
