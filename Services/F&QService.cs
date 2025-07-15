using BussiniessObject.Models;
using DataAccessLayer.DTOs.response;

namespace Services.Impl
{
    public class F_QService : F_QImpl
    {
        private readonly DatHiemContext _context;

        public F_QService(DatHiemContext context)
        {
            _context = context;
        }

        // Lấy tất cả câu hỏi từ database
        public async Task<IEnumerable<QuestionRes>> GetAllQuestionsAsync()
        {
            return await Task.Run(() =>
                _context.Questions.Select(q => new QuestionRes
                {
                    Id = q.Id,
                    GroupId = q.GroupId,
                    QuestionText = q.QuestionText,
                    AnswerText = q.AnswerText
                }).ToList()
            );
        }

        // Lấy câu hỏi theo Id từ database
        public async Task<QuestionRes?> GetQuestionByIdAsync(int id)
        {
            return await Task.Run(() =>
                _context.Questions
                    .Where(q => q.Id == id)
                    .Select(q => new QuestionRes
                    {
                        Id = q.Id,
                        GroupId = q.GroupId,
                        QuestionText = q.QuestionText,
                        AnswerText = q.AnswerText
                    })
                    .FirstOrDefault()
            );
        }
    }
}
