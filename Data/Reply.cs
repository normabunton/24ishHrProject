using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string ReplyText { get; set; }

        [Required]
        public Guid User { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        //Removed below foreignkey. Got an error in postman that wouldn't let me do anything because due to the FK for Post in Reply. The post already lives within the FK for the Comment. - CJ

        //[ForeignKey(nameof(Post))]

        //public int PostId { get; set; }
        //public virtual Post Post { get; set; }
    }
}
