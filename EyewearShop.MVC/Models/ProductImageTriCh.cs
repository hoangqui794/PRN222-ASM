using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ProductImageTriCh
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public int? DisplayOrder { get; set; }

    public int? ColorId { get; set; }

    public virtual ProductColorTriCh? Color { get; set; }

    public virtual ProductTriCh Product { get; set; } = null!;
}
