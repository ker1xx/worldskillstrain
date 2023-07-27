using System;
using System.Collections.Generic;

namespace apiworldskills.Models;

public partial class Competition
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public string? DateStart { get; set; }

    public string? DateEnd { get; set; }

    public string? Description { get; set; }

    public string? City { get; set; }
}
