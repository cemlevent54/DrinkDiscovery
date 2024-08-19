using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class Adminler
{
    public int AdminId { get; set; }

    public string AdminAd { get; set; } = null!;

    public string AdminSifre { get; set; } = null!;

    public byte[] AdminFotograf { get; set; } = null!;
}
