using System;
using System.Collections.Generic;

namespace ApplicationDomian.Models;

public partial class Position
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
