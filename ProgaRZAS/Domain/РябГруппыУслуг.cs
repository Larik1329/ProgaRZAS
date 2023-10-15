using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябГруппыУслуг
{
    public int РябIdГруппы { get; set; }

    public string? РябНазвание { get; set; }

    public int? РябIdДолжности { get; set; }

    public virtual РябДолжности? РябIdДолжностиNavigation { get; set; }

    public virtual ICollection<РябУслуги> РябУслугиs { get; set; } = new List<РябУслуги>();
}
