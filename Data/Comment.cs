using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public Guid User { get; set; }

        [ForeignKey (nameof(Post))]
        public int PostId { get; set; }

        public virtual List<Reply> Reply { get; set; }



    }
}
