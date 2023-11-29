using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанКлиенты
{
    public int ВанIdКлиента { get; set; }

    public string? ВанФио { get; set; }

    public string? ВанПостоянство { get; set; }

    public int ВанIdПосетителя { get; set; }

    public virtual ВанПосещения ВанIdПосетителяNavigation { get; set; } = null!;

    public virtual ВанКонтакты? ВанКонтакты { get; set; }
}
