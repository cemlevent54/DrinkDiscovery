using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class UserSweetCommentActions
    {
        [Key]
        public int id { get; set; }
        public string? user_id { get; set; }

        public int? comment_id { get; set; }
        public bool is_liked { get; set; }
    }
}
