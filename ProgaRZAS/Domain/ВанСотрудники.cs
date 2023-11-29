using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace ProgaRZAS.Domain;

public partial class ВанСотрудники
{
    public int ВанIdСотрудника { get; set; }

    public string? ВанФамилия { get; set; }

    public string? ВанИмя { get; set; }

    public string? ВанОтчество { get; set; }

    public string? ВанАдрес { get; set; }

    public string? ВанТелефон { get; set; }

    public int ВанIdДолжности { get; set; }

    public byte[]? ВанАдресШифр { get; set; }

    [ValidateNever]
    public virtual ВанДолжности ВанIdДолжностиNavigation { get; set; } = null!;

    [ValidateNever]
    public virtual ICollection<ВанОказанныеУслуги> ВанОказанныеУслугиs { get; set; } = new List<ВанОказанныеУслуги>();
}
