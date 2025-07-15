namespace DataAccessLayer.DTOs.response
{
    public class QuestionRes
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string QuestionText { get; set; } = null!;
        public string AnswerText { get; set; } = null!;
    }
}
