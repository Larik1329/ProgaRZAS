using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class Operator
{
    public int IdOperator { get; set; }

    public int IdApplication { get; set; }

    public string? InfApplication { get; set; }

    public virtual ICollection<HeadEducation> HeadEducations { get; set; } = new List<HeadEducation>();

    public virtual Application IdApplicationNavigation { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
