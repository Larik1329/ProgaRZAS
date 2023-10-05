using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class Application
{
    public int IdApplication { get; set; }

    public string? InspectorFio { get; set; }

    public DateTime? DateTest { get; set; }

    public virtual ICollection<Operator> Operators { get; set; } = new List<Operator>();
}
