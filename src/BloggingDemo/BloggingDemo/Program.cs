using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace BloggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run();

        }

        private void Run()
        {
            this.Welcome();
            //Display the blogs in the database.
            using(var context = new BloggingContext())
            {
                // Create and save a new blog
                WriteLine("Enter a name for a new Blog:");
                var name = ReadLine();
                var blog = new Blog
                {
                    Name = name
                };

                context.Blogs.Add(blog);
                context.SaveChanges();

                //Display all blogs from the database
                List<Blog> blogs = context.Blogs.ToList();
                DisplayBlogNames(blogs);
            }
        }

        private void DisplayBlogNames(List<Blog> blogs)
        {
            foreach (var item in blogs)
                WriteLine(item.Name);
        }

        private void Welcome()
        {
            WriteLine("Blogging Demo Program");
        }
    }
}
namespace Entities
{
    public class Blog
    {   
        //Primary Key, by convention
        public int BlogID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    } 

    public class Post
    {
        //Primary Key, by convention
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }//End of Post
}//End of Entities

namespace DAL
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base("name=BlogDb")
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}