﻿using System;
using System.Collections.Generic;

namespace apiworldskills.Models;

public partial class User
{
    public int? Id { get; set; }

    public string? Fio { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public double? Pin { get; set; }

    public DateTime? ДатаРождения { get; set; }

    public int? IdRole { get; set; }

    public int? Skill { get; set; }

    public int? Region { get; set; }

    public string? F10 { get; set; }

    public int? Место { get; set; }

    public int? Чемпионат { get; set; }

}
