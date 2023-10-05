using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class TestInf
{
    public int IdEducationManager { get; set; }

    public int IdTest { get; set; }

    public string? JudgingCriteria { get; set; }

    public string? TopicTest { get; set; }

    public string? Questions { get; set; }

    public string? RightAnswers { get; set; }

    public string? InspectorInformation { get; set; }

    public DateTime? DateTest { get; set; }

    public virtual EducationManager IdEducationManagerNavigation { get; set; } = null!;
}
