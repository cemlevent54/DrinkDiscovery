using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DrinkDiscovery_Admin_Revised.Models
{
    public class UserBeverageCommentActions
    {
        [Key]
        public int id { get; set; }
        public string? user_id { get; set; }
        
        public int? comment_id { get; set; }
        public bool is_liked { get; set; }

    }
}
