using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    User = _userId,
                    PostTitle = model.PostTitle,
                    PostText = model.PostText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<PostRead> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Post
                        .Where(e => e.User == _userId)
                        .Select(
                            e =>
                                new PostRead
                                {
                                    PostId = e.PostId,
                                    PostTitle = e.PostTitle,
                                    PostText = e.PostText
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
