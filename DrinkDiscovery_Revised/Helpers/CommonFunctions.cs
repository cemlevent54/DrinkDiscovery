using DrinkDiscovery_Revised.Controllers;
using DrinkDiscovery_Revised.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NuGet.Protocol.Core.Types;

namespace DrinkDiscovery_Revised.Helpers
{
    public class CommonFunctions
    {
        // database getirme işlemleri
        // sayfadaki kullanici id sini alma işlemi
        private IRepository repository;
        public static string ConvertToBase64String(byte[] imageBytes)
        {
            return imageBytes != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}" : null;
        }

        public UserService userService;

        public CommonFunctions(UserService _userService, IRepository _repository)
        {
            userService = _userService;
            repository=_repository;
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

        //public void StartIncompleteOrderCleanup(int orderId)
        //{
        //    Task.Run(async () =>
        //    {
        //        // Wait for 30 minutes (or however long you want)
        //        await Task.Delay(TimeSpan.FromMinutes(30));

        //        // Re-fetch the order from the database
        //        var order = await repository.FindAsync<Order>(o => o.OrderId == orderId);

        //        // Check if the order is still incomplete
        //        if (order != null && order.OrderStatus == "incomplete")
        //        {
        //            // Delete the order if still incomplete
        //            repository.Remove(order);
        //            await repository.SaveChangesAsync();
        //        }
        //    });
        //}

    }
}
