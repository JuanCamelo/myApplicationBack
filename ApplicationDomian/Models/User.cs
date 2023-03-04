using System;
using System.Collections.Generic;

namespace ApplicationDomian.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string User1 { get; set; } = null!;

    public Guid IdPosition { get; set; }

    public int Phone { get; set; }

    public string Gmail { get; set; } = null!;

    public Guid IdTypeContact { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual Position IdPositionNavigation { get; set; } = null!;

    public virtual TypeContact IdTypeContactNavigation { get; set; } = null!;
}
