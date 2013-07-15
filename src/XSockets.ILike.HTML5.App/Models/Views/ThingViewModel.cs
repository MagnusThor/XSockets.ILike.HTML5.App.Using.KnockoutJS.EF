using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSockets.ILike.HTML5.App.Models.Views
{
    public class ThingViewModel
    {
        public int Id { get; set; }
       
        public string Caption { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public IList<LikeViewModel> Likes { get; set; }

        public ThingViewModel(Thing thing)
        {

            this.Id = thing.Id;
            this.Caption = thing.Caption;
            this.Description = thing.Description;
            this.Created = thing.Created;

            this.Likes = new List<LikeViewModel>();

            foreach (var like in thing.Likes)
            {
                this.Likes.Add(new LikeViewModel(like));
            }


            
        }
    }

    public class LikeViewModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime Created { get; set; }
 
        public LikeViewModel(Like like)
        {

            this.Id = like.Id;
            this.Score = like.Score;
            this.Created = like.Created;


        }
    }
}