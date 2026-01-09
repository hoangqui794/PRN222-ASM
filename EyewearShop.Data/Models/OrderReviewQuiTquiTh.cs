using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class OrderReviewQuiTquiTh
{
    public int ReviewId { get; set; }

    public int OrderId { get; set; }

    public int StaffId { get; set; }

    public int? PrescriptionId { get; set; }

    public string ReviewType { get; set; } = null!;

    public string ReviewStatus { get; set; } = null!;

    public string? IssueNote { get; set; }

    public bool? CustomerContacted { get; set; }

    public string? ContactMethod { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual UserAccount Staff { get; set; } = null!;
}
