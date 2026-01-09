using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class RefundTaiNd
{
    public int RefundIdTaiNd { get; set; }

    public int RequestId { get; set; }

    public string RefundMethod { get; set; } = null!;

    public decimal RefundAmount { get; set; }

    public DateTime? RefundDate { get; set; }

    public string? TransactionId { get; set; }

    public virtual AfterSalesTaiNd Request { get; set; } = null!;
}
