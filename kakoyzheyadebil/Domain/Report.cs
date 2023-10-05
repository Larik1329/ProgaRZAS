using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class Report
{
    public int IdOperator { get; set; }

    public int IdReport { get; set; }

    public int IdEducationManager { get; set; }

    public int IdInspector { get; set; }

    public int IdApplication { get; set; }

    public string? InspectorInformation { get; set; }

    public DateTime? DateTest { get; set; }

    public int? ScoreInspector { get; set; }

    public virtual Operator Id { get; set; } = null!;

    public virtual TestResult IdNavigation { get; set; } = null!;
}
