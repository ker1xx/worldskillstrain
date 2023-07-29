using System;
using System.Collections.Generic;

namespace apiworldskills.Models;

public partial class Competitor
{
    public int? Id { get; set; }

    public string? Ip { get; set; }

    public string? NameOfPc { get; set; }

    public DateTime? DatetimeOfLogin { get; set; }
}
