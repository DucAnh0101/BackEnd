using BussiniessObject.Models;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;

namespace Services.Impl
{
    public class F_QService : F_QImpl
    {
        private readonly DatHiemContext _context;

        public F_QService(DatHiemContext context)
        {
            _context = context;
        }

        // Lấy tất cả câu hỏi từ database, trả về tên nhóm
        public async Task<IEnumerable<QuestionRes>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                .Include(q => q.Group)
                .Select(static q => new QuestionRes
                {
                    Id = q.Id,
                    GroupName = q.Group.Name,
                    QuestionText = q.QuestionText,
                    AnswerText = q.AnswerText
                })
                .ToListAsync();
        }

        // Lấy câu hỏi theo Id từ database, trả về tên nhóm
        public async Task<QuestionRes?> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Group)
                .Where(q => q.Id == id)
                .Select(q => new QuestionRes
                {
                    Id = q.Id,
                    GroupName = q.Group.Name,
                    QuestionText = q.QuestionText,
                    AnswerText = q.AnswerText
                })
                .FirstOrDefaultAsync();
        }

        // Lấy danh sách câu hỏi theo group_id
        public async Task<IEnumerable<QuestionRes>> GetQuestionsByGroupIdAsync(int groupId)
        {
            return await _context.Questions
                .Include(q => q.Group)
                .Where(q => q.GroupId == groupId)
                .Select(q => new QuestionRes
                {
                    Id = q.Id,
                    GroupName = q.Group.Name,
                    QuestionText = q.QuestionText,
                    AnswerText = q.AnswerText
                })
                .ToListAsync();
        }
    }
}
