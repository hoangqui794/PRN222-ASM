using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class OrderItemNamtmh
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int VariantId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int? PrescriptionId { get; set; }

    public virtual OrderNamtmh Order { get; set; } = null!;

    public virtual ICollection<PrescriptionPhuHn> PrescriptionPhuHns { get; set; } = new List<PrescriptionPhuHn>();
}
