using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string  PostTitle { get; set; }
        [Required]
        public string PostText { get; set; }
        [Required]
        public virtual List<Comment> Comment { get; set; }

<<<<<<< HEAD:Data/SocMed.cs
=======
        [Required]
        public Guid User { get; set; }

>>>>>>> 9bb5a2b44fd1419c50dbde27c60580fdc75b04ee:Data/Post.cs
    }
}
