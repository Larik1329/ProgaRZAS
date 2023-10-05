using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class InspectorsList
{
    public int IdOperator { get; set; }

    public int IdHeadEducation { get; set; }

    public int IdEducationManager { get; set; }

    public int IdInspector { get; set; }

    public int IdApplication { get; set; }

    public string? InspectorFio { get; set; }

    public DateTime? DateTest { get; set; }

    public string? InspectorEmail { get; set; }

    public string? InspectorTelephone { get; set; }

    public string? InspectorPassport { get; set; }

    public string? InspectorAddress { get; set; }

    public virtual HeadEducation Id { get; set; } = null!;

    public virtual EducationManager IdEducationManagerNavigation { get; set; } = null!;
}
