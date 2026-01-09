using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class ProductTriCh
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Sku { get; set; }

    public int? CategoryId { get; set; }

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? FrameType { get; set; }

    public string? Material { get; set; }

    public string? Dimensions { get; set; }

    public int? StockQuantity { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CategoryTriCh? Category { get; set; }

    public virtual ICollection<ProductColorTriCh> ProductColorTriChes { get; set; } = new List<ProductColorTriCh>();

    public virtual ICollection<ProductImageTriCh> ProductImageTriChes { get; set; } = new List<ProductImageTriCh>();

    public virtual ICollection<ProductReviewMiLtt> ProductReviewMiLtts { get; set; } = new List<ProductReviewMiLtt>();
}
