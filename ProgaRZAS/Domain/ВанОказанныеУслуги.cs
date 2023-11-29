using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанОказанныеУслуги
{
    public int ВанIdУслуги { get; set; }

    public int ВанIdГруппы { get; set; }

    public int ВанIdСотрудника { get; set; }

    public int ВанIdПосетителя { get; set; }

    public int? ВанСкидка { get; set; }

    public virtual ВанУслуги Ван { get; set; } = null!;

    public virtual ВанПосещения ВанIdПосетителяNavigation { get; set; } = null!;

    public virtual ВанСотрудники ВанIdСотрудникаNavigation { get; set; } = null!;
}
