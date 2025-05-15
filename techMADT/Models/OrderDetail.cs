using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class OrderDetail
{
    public int DetailsId { get; set; }

    public int OrId { get; set; }

    public int ProductId { get; set; }

    public int Pieces { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Order Or { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
