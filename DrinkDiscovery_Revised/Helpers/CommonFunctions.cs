using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DrinkDiscovery_Revised.Helpers
{
    public class CommonFunctions
    {
        // database getirme işlemleri
        // sayfadaki kullanici id sini alma işlemi
        public static string ConvertToBase64String(byte[] imageBytes)
        {
            return imageBytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}" : null;
        }
    }
}
