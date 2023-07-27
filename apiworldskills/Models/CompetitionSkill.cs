using System;
using System.Collections.Generic;

namespace apiworldskills.Models;

public partial class CompetitionSkill
{
    public int? Id { get; set; }

    public int? CompetitionId { get; set; }

    public int? SkillId { get; set; }
}
