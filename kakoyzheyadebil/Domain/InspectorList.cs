using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class InspectorList
{
    public double? IdOperator { get; set; }

    public double? IdHeadEducation { get; set; }

    public double? IdEducationManager { get; set; }

    public double? IdInspector { get; set; }

    public double? IdApplication { get; set; }

    public string? InspectorFio { get; set; }

    public DateTime? DateTest { get; set; }

    public string? InspectorEmail { get; set; }

    public string? InspectorTelephone { get; set; }

    public double? InspectorPassport { get; set; }

    public string? InspectorAddress { get; set; }
}
