using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BussiniessObject.Models;

public partial class Question
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string AnswerText { get; set; } = null!;

    public virtual QuestionGroup Group { get; set; }
}
