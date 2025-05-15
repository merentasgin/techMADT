using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class Product
{
    public int PrId { get; set; }

    public string PrName { get; set; } = null!;

    public int CatId { get; set; }

    public int BrandId { get; set; }

    public decimal? Price { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Cat { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
