using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int PrId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Pr { get; set; } = null!;
}
