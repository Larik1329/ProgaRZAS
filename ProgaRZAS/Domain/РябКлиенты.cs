using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябКлиенты
{
    public int РябIdКлиента { get; set; }

    public string? РябФио { get; set; }

    public string? РябПостоянство { get; set; }

    public int РябIdПосетителя { get; set; }

    public virtual РябПосещения РябIdПосетителяNavigation { get; set; } = null!;

    public virtual РябКонтакты? РябКонтакты { get; set; }
}
