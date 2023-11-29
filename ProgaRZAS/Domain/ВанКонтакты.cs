using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанКонтакты
{
    public int ВанIdКлиента { get; set; }

    public int? ВанEmail { get; set; }

    public int? ВанТелефон { get; set; }

    public string? ВанTelegram { get; set; }

    public string? ВанSkype { get; set; }

    public int ВанIdПосетителя { get; set; }

    public virtual ВанКлиенты Ван { get; set; } = null!;
}
