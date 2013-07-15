namespace XSockets.ILike.HTML5.App.Models
{
   
    public class Like : PersistentEntity
    {
        public int Score { get; set; }
        public Thing Thing { get; set; }
    }
}