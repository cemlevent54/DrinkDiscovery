using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class UserSweetCommentAction
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? CommentId { get; set; }

    public bool IsLiked { get; set; }
}
