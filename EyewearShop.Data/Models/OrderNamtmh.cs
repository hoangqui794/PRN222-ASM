using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class OrderNamtmh
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public string OrderType { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? ShippingFee { get; set; }

    public decimal FinalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string? ShippingAddress { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AfterSalesTaiNd> AfterSalesTaiNds { get; set; } = new List<AfterSalesTaiNd>();

    public virtual UserAccount Customer { get; set; } = null!;

    public virtual ICollection<OrderItemNamtmh> OrderItemNamtmhs { get; set; } = new List<OrderItemNamtmh>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<ProductReviewMiLtt> ProductReviewMiLtts { get; set; } = new List<ProductReviewMiLtt>();

    public virtual ICollection<ProductionSonKn> ProductionSonKns { get; set; } = new List<ProductionSonKn>();
}
