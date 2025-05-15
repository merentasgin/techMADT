using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int UsId { get; set; }

    public string City { get; set; } = null!;

    public string Discrict { get; set; } = null!;

    public string Neighbourhood { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public virtual User Us { get; set; } = null!;
}
