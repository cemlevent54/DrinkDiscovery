namespace DrinkDiscovery.Models
{
    public class Functions
    {
        public static string GetImage(string image)
        {
            if (image != null)
            {
                return "data:image/jpeg;base64," + image;
            }
            return null;
        }
    }
}
