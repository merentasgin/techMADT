using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class User
{
    public int UsId { get; set; }

    public string UsName { get; set; } = null!;

    public string UsSurname { get; set; } = null!;

    public string UsEmail { get; set; } = null!;

    public string UsPassword { get; set; } = null!;

    public string UsNickname { get; set; } = null!;

    public DateTime UsCreatedDate { get; set; }

    public int? UsType { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual LoginType? UsTypeNavigation { get; set; }
}
