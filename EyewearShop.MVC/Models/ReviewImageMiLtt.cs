using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ReviewImageMiLtt
{
    public int ImageId { get; set; }

    public int ReviewId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime? UploadedAt { get; set; }

    public virtual ProductReviewMiLtt Review { get; set; } = null!;
}
