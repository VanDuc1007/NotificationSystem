
using System;
using System.Collections.Generic;
using static ApplicationDbContext;

public class UserService
{
    private readonly SocialMediaContext _context;

    public UserService(SocialMediaContext context)
    {
        _context = context;
    }

    public void AddUser(string userName)
    {
        var user = new User { Name = userName };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void AddFollower(Guid userId, Guid followerId)
    {
        var userFollower = new UserFollowers { UserId = userId, FollowerId = followerId };
        _context.UserFollowers.Add(userFollower);
        _context.SaveChanges();
    }

    public void CreatePost(User us, string name, string content)
    {
        var post = new Post { UserId = us.Id, Content = content };
        _context.Posts.Add(post);
        _context.SaveChanges();

        // Xuất thông báo ra console
        Console.WriteLine($"Post created by {us.Name}  : {content}");
        Console.WriteLine($"User message : {name}");
    }

    // Các phương thức khác nếu cần
}

