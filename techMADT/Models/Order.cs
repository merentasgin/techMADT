using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class Order
{
    public int OrId { get; set; }

    public int UsId { get; set; }

    public byte[] OrDate { get; set; } = null!;

    public string OrStatus { get; set; } = null!;

    public decimal OrTotalPrice { get; set; }

    public int OrPieces { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User Us { get; set; } = null!;
}
