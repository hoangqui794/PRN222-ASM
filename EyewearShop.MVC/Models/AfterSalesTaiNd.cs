using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class AfterSalesTaiNd
{
    public int RequestIdTaiNd { get; set; }

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public string RequestType { get; set; } = null!;

    public string? Reason { get; set; }

    public string? RequestStatus { get; set; }

    public decimal? RefundAmount { get; set; }

    public int? ExchangeProductId { get; set; }

    public DateTime? RequestedAt { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public int? ProcessedBy { get; set; }

    public string? ResolutionNotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual OrderNamtmh Order { get; set; } = null!;

    public virtual UserAccount? ProcessedByNavigation { get; set; }

    public virtual ICollection<RefundTaiNd> RefundTaiNds { get; set; } = new List<RefundTaiNd>();
}
