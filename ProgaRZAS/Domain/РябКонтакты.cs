using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябКонтакты
{
    public int РябIdКлиента { get; set; }

    public int? РябEmail { get; set; }

    public int? РябТелефон { get; set; }

    public string? РябTelegram { get; set; }

    public string? РябSkype { get; set; }

    public int РябIdПосетителя { get; set; }

    public virtual РябКлиенты Ряб { get; set; } = null!;
}
