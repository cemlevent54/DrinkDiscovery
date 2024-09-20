using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class UserWithRolesViewModel
    {
        public string Id { get; set; }
        public string kullanici_ad { get; set; }
        public string kullanici_soyad { get; set; }
        public string kullanici_mail { get; set; }
        public string kullanici_telefon { get; set; }
        public string kullanici_username { get; set; }
        public string Role { get; set; } // Seçilen rol
        public List<SelectListItem> RolesList { get; set; } // Rolleri göstermek için liste
    }
}
