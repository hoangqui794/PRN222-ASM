using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class LensServicePhuHn
{
    public int ServiceId { get; set; }

    public int PrescriptionId { get; set; }

    public int LensTypeId { get; set; }

    public string? CoatingType { get; set; }

    public decimal ServicePrice { get; set; }

    public virtual PrescriptionPhuHn Prescription { get; set; } = null!;
}
