using System.Collections.Generic;
using System.Linq;
using XSockets.Core.XSocket.Helpers; // <- Important add this to gain access to the neat helpers :-)
using XSockets.ILike.HTML5.App.DataBase;
using XSockets.ILike.HTML5.App.Models;
using XSockets.ILike.HTML5.App.Models.Views;

namespace XSockets.ILike.HTML5.App.Controllers
{
    public class RealtimeController : XSockets.Core.XSocket.XBaseSocket
    {

       
        public void Things()
        {
            var ctx = new AppDbContext();
            var things = ctx.Things;
            var all = new List<ThingViewModel>();

            foreach (var thing in things)
            {
            all.Add(new ThingViewModel(thing));
            }

            this.Send(all.OrderByDescending(p => p.Likes.Count), "Things"); 
            // Send (return) all exisiting things to the client using Topic 'Things'
        }

        public void ThingSaveOrUpdate(Thing model)
        {
            var ctx = new DataBase.AppDbContext();
            ctx.Things.Add(model);
            ctx.SaveChanges();  
            this.SendToAll(new ThingViewModel(model), "ThingSaveOrUpdate"); // Lets notify all client about the new thing!
        }

        public void AddLikeToThing(int thingId, int score)
        {
            var ctx = new DataBase.AppDbContext();
            var thing = ctx.Things.SingleOrDefault(t => t.Id.Equals(thingId));
            thing.Likes.Add(new Like(){ Score =  score});
            ctx.SaveChanges();
            this.SendToAll(new ThingViewModel(thing),"Liked"); // Lets notift all the client about the new like!
      
        }
       
    }
}