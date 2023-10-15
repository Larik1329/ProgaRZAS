using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class РябСотрудники
{
    public int РябIdСотрудника { get; set; }

    public string? РябФамилия { get; set; }

    public string? РябИмя { get; set; }

    public string? РябОтчество { get; set; }

    public string? РябАдрес { get; set; }

    public string? РябТелефон { get; set; }

    public int РябIdДолжности { get; set; }

    public byte[]? РябАдресШифр { get; set; }

    [ValidateNever]
    public virtual РябДолжности РябIdДолжностиNavigation { get; set; } = null!;

    [ValidateNever]
    public virtual ICollection<РябОказанныеУслуги> РябОказанныеУслугиs { get; set; } = new List<РябОказанныеУслуги>();
}
