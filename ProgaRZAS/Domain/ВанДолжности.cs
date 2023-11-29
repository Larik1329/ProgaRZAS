using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанДолжности
{
    public int ВанIdДолжности { get; set; }

    public string? ВанНазвание { get; set; }

    public string? ВанГруппаУслуг { get; set; }

    public string? ВанГрафикРаботы { get; set; }

    public virtual ICollection<ВанГруппыУслуг> ВанГруппыУслугs { get; set; } = new List<ВанГруппыУслуг>();

    public virtual ICollection<ВанСотрудники> ВанСотрудникиs { get; set; } = new List<ВанСотрудники>();
}
