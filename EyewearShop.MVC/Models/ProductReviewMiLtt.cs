using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ProductReviewMiLtt
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public int OrderId { get; set; }

    public byte Rating { get; set; }

    public string Comment { get; set; } = null!;

    public bool? IsVerified { get; set; }

    public int? LikeCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual OrderNamtmh Order { get; set; } = null!;

    public virtual ProductTriCh Product { get; set; } = null!;

    public virtual ICollection<ReviewImageMiLtt> ReviewImageMiLtts { get; set; } = new List<ReviewImageMiLtt>();

    public virtual UserAccount User { get; set; } = null!;
}
