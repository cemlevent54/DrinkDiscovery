using DrinkDiscovery_Revised.Controllers;
using DrinkDiscovery_Revised.Models;
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

        public UserService userService;

        public CommonFunctions(UserService _userService)
        {
            userService = _userService;
        }

        // Retrieves user information for a list of comments
        public async Task<Dictionary<string, Tuple<string, byte[], int>>> GetUserInfosAsync<T>(List<T> yorumlar)
        {
            var userInfos = new Dictionary<string, Tuple<string, byte[], int>>();

            foreach (var yorum in yorumlar)
            {
                var yorumKullaniciIdProperty = yorum.GetType().GetProperty("YorumKullaniciId");
                var yorumIdProperty = yorum.GetType().GetProperty("YorumId");

                if (yorumKullaniciIdProperty != null && yorumIdProperty != null)
                {
                    var yorumKullaniciId = yorumKullaniciIdProperty.GetValue(yorum).ToString();
                    var yorumId = (int)yorumIdProperty.GetValue(yorum);

                    var user = await userService.GetUserDetailsByIdAsync(yorumKullaniciId);

                    if (user != null && !userInfos.ContainsKey(yorumKullaniciId))
                    {
                        userInfos.Add(yorumKullaniciId, Tuple.Create(user.kullanici_username, user.kullanici_fotograf, yorumId));
                    }
                }
            }

            return userInfos;
        }
    }
}
