using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябОказанныеУслуги
{
    public int РябIdУслуги { get; set; }

    public int РябIdГруппы { get; set; }

    public int РябIdСотрудника { get; set; }

    public int РябIdПосетителя { get; set; }

    public int? РябСкидка { get; set; }

    public virtual РябУслуги Ряб { get; set; } = null!;

    public virtual РябПосещения РябIdПосетителяNavigation { get; set; } = null!;

    public virtual РябСотрудники РябIdСотрудникаNavigation { get; set; } = null!;
}
