using System;
using System.Collections.Generic;

namespace BussiniessObject.Models;

public partial class QuestionGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; }

}
