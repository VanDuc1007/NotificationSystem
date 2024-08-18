// Program.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using static ApplicationDbContext;

public class Program
{
    static void Main(string[] args)
    {
        using (var context = new SocialMediaContext())
        {
            var userService = new UserService(context);

            // Thêm người dùng
            userService.AddUser("Alice");
            userService.AddUser("Bob");

            // Lấy thông tin người dùng từ cơ sở dữ liệu
            var alice = context.Users.FirstOrDefault(u => u.Name == "Alice");
            var bob = context.Users.FirstOrDefault(u => u.Name == "Bob");

            if (alice != null && bob != null)
            {
                // Bob theo dõi Alice
                userService.AddFollower(alice.Id, bob.Id);

                // Alice đăng bài
                userService.CreatePost(alice, bob.Name, "Xin chào mọi người!");
            }
        }

        Console.WriteLine("Dữ liệu đã được chèn thành công.");
    }

}


