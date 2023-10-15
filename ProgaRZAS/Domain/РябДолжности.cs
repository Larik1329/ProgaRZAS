using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябДолжности
{
    public int РябIdДолжности { get; set; }

    public string? РябНазвание { get; set; }

    public string? РябГруппаУслуг { get; set; }

    public string? РябГрафикРаботы { get; set; }

    public virtual ICollection<РябГруппыУслуг> РябГруппыУслугs { get; set; } = new List<РябГруппыУслуг>();

    public virtual ICollection<РябСотрудники> РябСотрудникиs { get; set; } = new List<РябСотрудники>();
}
