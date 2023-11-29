using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанУслуги
{
    public int ВанIdУслуги { get; set; }

    public string? ВанНазвание { get; set; }

    public int? ВанСебестоимость { get; set; }

    public int? ВанЦена { get; set; }

    public string? ВанОписаниеУслуги { get; set; }

    public int ВанIdГруппы { get; set; }

    public virtual ВанГруппыУслуг ВанIdГруппыNavigation { get; set; } = null!;

    public virtual ICollection<ВанОказанныеУслуги> ВанОказанныеУслугиs { get; set; } = new List<ВанОказанныеУслуги>();
}
