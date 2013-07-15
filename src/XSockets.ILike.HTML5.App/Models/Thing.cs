using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSockets.ILike.HTML5.App.Models
{
    // Things that  can liked
    public class Thing : PersistentEntity
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public virtual List<Like> Likes { get; set; } 
    }
}