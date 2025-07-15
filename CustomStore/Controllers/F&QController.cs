using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.DTOs.response;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services.Impl;

namespace CustomStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F_QController : ControllerBase
    {
        private readonly F_QService _fQService;

        public F_QController(F_QService fQService)
        {
            _fQService = fQService;
        }

        // Lấy tất cả câu hỏi
        [HttpGet("questions")]
        public async Task<ActionResult<IEnumerable<QuestionRes>>> GetAllQuestions()
        {
            var questions = await _fQService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        // Lấy câu hỏi theo Id
        [HttpGet("questions/{id}")]
        public async Task<ActionResult<QuestionRes>> GetQuestionById(int id)
        {
            var question = await _fQService.GetQuestionByIdAsync(id);
            if (question == null)
                return NotFound();
            return Ok(question);
        }
    }
}