using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ShipmentSonKn
{
    public int ShipmentSonKnid { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public string? ShippingCompany { get; set; }

    public DateOnly? ShippedDate { get; set; }

    public DateOnly? DeliveredDate { get; set; }

    public bool? IsDelivered { get; set; }

    public virtual ProductionSonKn? ProductionSonKn { get; set; }
}
