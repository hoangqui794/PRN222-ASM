using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class CustomerSupportQuiTh
{
    public int SupportId { get; set; }

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public string? IssueType { get; set; }

    public string? Resolution { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual UserAccount Staff { get; set; } = null!;
}
