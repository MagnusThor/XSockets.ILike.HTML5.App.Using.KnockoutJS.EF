using System;
using System.ComponentModel.DataAnnotations;

namespace XSockets.ILike.HTML5.App.Models
{
     
    public class PersistentEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public PersistentEntity()
        {
            this.Created = DateTime.Now;
        }
    }
}