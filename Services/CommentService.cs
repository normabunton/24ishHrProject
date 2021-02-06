using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var post = ctx.Post.SingleOrDefault(p => p.PostId == model.PostId);
            var entity =
                new Comment()
                {
                    User = _userId,
                    CommentText = model.Content,
                    PostId = model.PostId,
                   // Post = post //NEED TO LINK TO FK/VIRTUAL??
                };
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
                    .Include(e=>e.Post)
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
