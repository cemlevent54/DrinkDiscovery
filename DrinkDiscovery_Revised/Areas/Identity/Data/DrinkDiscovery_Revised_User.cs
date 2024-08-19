using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DrinkDiscovery_Revised.Areas.Identity.Data;

// Add profile data for application users by adding properties to the DrinkDiscovery_Revised_User class
public class DrinkDiscovery_Revised_User : IdentityUser
{
    public string? kullanici_ad { get; set; }

    public string? kullanici_soyad { get; set; } 

    public string? kullanici_sifre { get; set; } 

    public string? kullanici_mail { get; set; } 

    public string? kullanici_telefon { get; set; } 

    public byte[]? kullanici_fotograf { get; set; } 

    public string? kullanici_username { get; set; }
}

