using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанПосещения
{
    public int ВанIdПосетителя { get; set; }

    public string? ВанКомментарийКлиента { get; set; }

    public DateTime? ВанДата { get; set; }

    public string? ВанУслугаОказана { get; set; }

    public virtual ICollection<ВанКлиенты> ВанКлиентыs { get; set; } = new List<ВанКлиенты>();

    public virtual ICollection<ВанОказанныеУслуги> ВанОказанныеУслугиs { get; set; } = new List<ВанОказанныеУслуги>();
}
