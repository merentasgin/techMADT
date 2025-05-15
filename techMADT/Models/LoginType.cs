using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class LoginType
{
    public int UsType { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
