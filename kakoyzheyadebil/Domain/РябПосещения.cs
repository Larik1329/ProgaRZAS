using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябПосещения
{
    public int РябIdПосетителя { get; set; }

    public string? РябКомментарийКлиента { get; set; }

    public DateTime? РябДата { get; set; }

    public string? РябУслугаОказана { get; set; }

    public virtual ICollection<РябКлиенты> РябКлиентыs { get; set; } = new List<РябКлиенты>();

    public virtual ICollection<РябОказанныеУслуги> РябОказанныеУслугиs { get; set; } = new List<РябОказанныеУслуги>();
}
