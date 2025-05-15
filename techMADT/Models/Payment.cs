using System;
using System.Collections.Generic;

namespace techMADT.Models;

public partial class Payment
{
    public int PayId { get; set; }

    public int OrId { get; set; }

    public string PayMethod { get; set; } = null!;

    public string PayStatus { get; set; } = null!;

    public byte[] CreatedDate { get; set; } = null!;

    public virtual Order Or { get; set; } = null!;
}
