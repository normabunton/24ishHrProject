using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Reply()
                    {
                        User = _userId,
                        ReplyText = model.ReplyContent,
                        CommentId = model.CommentId,
                    };
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reply
                    .Where(e => e.User == _userId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyContent = e.ReplyText,
                            CommentId = e.CommentId,
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
