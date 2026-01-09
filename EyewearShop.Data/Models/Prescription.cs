using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int OrderId { get; set; }

    public int OrderItemId { get; set; }

    public int CustomerId { get; set; }

    public decimal? RightEyeSph { get; set; }

    public decimal? RightEyeCyl { get; set; }

    public int? RightEyeAxis { get; set; }

    public decimal? LeftEyeSph { get; set; }

    public decimal? LeftEyeCyl { get; set; }

    public int? LeftEyeAxis { get; set; }

    public decimal? PupillaryDistance { get; set; }

    public bool IsCustomLens { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<LensService> LensServices { get; set; } = new List<LensService>();

    public virtual OrderNamtmh Order { get; set; } = null!;

    public virtual OrderItemNamtmh OrderItem { get; set; } = null!;
}
