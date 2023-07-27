using System;
using System.Collections.Generic;

namespace apiworldskills.Models;

public partial class Skill
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public int? SkillBlockId { get; set; }

    public double? IsFuture { get; set; }

    public string? Description { get; set; }

    public double? ПлощадьНаРабочееМестоКвМ { get; set; }

    public double? ПлощадьКомнатыОценкиНаОднуЭкспертнуюГруппуКвМ { get; set; }

    public double? ЗонаБрифингаКвМ { get; set; }

    public double? ПлощадьСкладаКвМ { get; set; }

    public double? F10 { get; set; }

    public double? КоличествоУчастниковВКоманде { get; set; }
}
