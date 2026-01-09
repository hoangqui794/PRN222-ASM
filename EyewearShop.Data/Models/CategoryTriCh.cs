using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class CategoryTriCh
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Slug { get; set; }

    public int? ParentId { get; set; }

    public byte? Status { get; set; }

    public virtual ICollection<ProductTriCh> ProductTriChes { get; set; } = new List<ProductTriCh>();
}
