using System;
using System.Collections.Generic;

namespace EyewearShop.MVC.Models;

public partial class ProductionSonKn
{
    public int ProductionSonKnid { get; set; }

    public int OrderId { get; set; }

    public int AssignedTo { get; set; }

    public int? ShipmentSonKnid { get; set; }

    public string? ProductionCode { get; set; }

    public string? ProductionNote { get; set; }

    public string? ProductionStatus { get; set; }

    public bool? IsUrgent { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ExpectedFinishDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual UserAccount AssignedToNavigation { get; set; } = null!;

    public virtual OrderNamtmh Order { get; set; } = null!;

    public virtual ShipmentSonKn? ShipmentSonKn { get; set; }
}
