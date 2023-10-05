using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class Report1
{
    public double? IdOperator { get; set; }

    public double? IdReport { get; set; }

    public double? IdEducationManager { get; set; }

    public double? IdInspector { get; set; }

    public double? IdApplication { get; set; }

    public string? InspectorInformation { get; set; }

    public DateTime? DateTest { get; set; }

    public double? ScoreInspector { get; set; }
}
