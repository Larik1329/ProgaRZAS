using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class HeadEducation
{
    public int IdOperator { get; set; }

    public int IdHeadEducation { get; set; }

    public int IdApplication { get; set; }

    public string? InspectorFio { get; set; }

    public string? InspectorEmail { get; set; }

    public string? InspectorTelephone { get; set; }

    public string? InspectorAddress { get; set; }

    public string? InspectorPassport { get; set; }

    public string? InfApplication { get; set; }

    public virtual Operator Id { get; set; } = null!;

    public virtual ICollection<InspectorsList> InspectorsLists { get; set; } = new List<InspectorsList>();
}
