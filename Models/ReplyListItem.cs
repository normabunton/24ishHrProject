using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReplyListItem
    {
        public string ReplyContent { get; set; }

        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
