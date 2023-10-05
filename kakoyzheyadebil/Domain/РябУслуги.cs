using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябУслуги
{
    public int РябIdУслуги { get; set; }

    public string? РябНазвание { get; set; }

    public int? РябСебестоимость { get; set; }

    public int? РябЦена { get; set; }

    public string? РябОписаниеУслуги { get; set; }

    public int РябIdГруппы { get; set; }

    public virtual РябГруппыУслуг РябIdГруппыNavigation { get; set; } = null!;

    public virtual ICollection<РябОказанныеУслуги> РябОказанныеУслугиs { get; set; } = new List<РябОказанныеУслуги>();
}
