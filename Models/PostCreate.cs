using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "You must enter a title for your post")]
        [MaxLength(75, ErrorMessage = "You title must be less than 75 characters")]
        public string PostTitle { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You must enter content for your post")]
        [MaxLength(5000, ErrorMessage = "Jeez, are you writing an essay? Make it shorter")]
        public string PostText { get; set; }
    }
}
