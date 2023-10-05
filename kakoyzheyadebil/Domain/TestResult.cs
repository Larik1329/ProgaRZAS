using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class TestResult
{
    public int IdOperator { get; set; }

    public int IdEducationManager { get; set; }

    public int IdInspector { get; set; }

    public int IdApplication { get; set; }

    public string? InspectorInformation { get; set; }

    public int? ScoreInspector { get; set; }

    public DateTime? DateTest { get; set; }

    public virtual EducationManager IdOperatorNavigation { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
