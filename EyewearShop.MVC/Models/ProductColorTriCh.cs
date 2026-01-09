using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ProductColorTriCh
{
    public int ColorId { get; set; }

    public int ProductId { get; set; }

    public string ColorName { get; set; } = null!;

    public string? ColorCode { get; set; }

    public int? StockQuantity { get; set; }

    public virtual ProductTriCh Product { get; set; } = null!;

    public virtual ICollection<ProductImageTriCh> ProductImageTriChes { get; set; } = new List<ProductImageTriCh>();
}
