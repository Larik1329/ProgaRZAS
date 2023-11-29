using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанГруппыУслуг
{
    public int ВанIdГруппы { get; set; }

    public string? ВанНазвание { get; set; }

    public int? ВанIdДолжности { get; set; }

    public virtual ВанДолжности? ВанIdДолжностиNavigation { get; set; }

    public virtual ICollection<ВанУслуги> ВанУслугиs { get; set; } = new List<ВанУслуги>();
}
