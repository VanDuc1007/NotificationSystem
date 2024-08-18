// Models.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<UserFollowers> Followers { get; set; } = new List<UserFollowers>();
}
public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

public class UserFollowers
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid FollowerId { get; set; }
    public User Follower { get; set; }
}


