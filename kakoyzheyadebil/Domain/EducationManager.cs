using System;
using System.Collections.Generic;

namespace kakoyzheyadebil.Domain;

public partial class EducationManager
{
    public int IdEducationManager { get; set; }

    public DateTime? DateTest { get; set; }

    public string? InspectorInformation { get; set; }

    public string? JudgingCriteria { get; set; }

    public virtual ICollection<InspectorsList> InspectorsLists { get; set; } = new List<InspectorsList>();

    public virtual ICollection<TestInf> TestInfs { get; set; } = new List<TestInf>();

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
