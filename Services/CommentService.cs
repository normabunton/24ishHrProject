using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        //private readonly int _postId;
        //private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public CommentService(Guid userId)
        {
            _userId = userId;
            //_postId = postId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    User = _userId,
                    CommentText = model.Content,
                    PostId = model.PostId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comment
                    .Where(e => e.User == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            Content = e.CommentText,
                            PostId = e.PostId,
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
