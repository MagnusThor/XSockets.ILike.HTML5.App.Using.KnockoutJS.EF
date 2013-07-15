using System.Data.Entity;
using XSockets.ILike.HTML5.App.Models;

namespace XSockets.ILike.HTML5.App.DataBase
{
    public class AppDbContext : System.Data.Entity.DbContext
    {

        static AppDbContext()
        {
               Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
        }

        public AppDbContext()
        {
        }

        public DbSet<Like> Likes { get; set; }
  
        public DbSet<Thing> Things { get; set; } 

    }
}