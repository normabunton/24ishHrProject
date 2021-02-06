using Data;
using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24ishHourAssignment.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            //var post = _context.Post.Find(id);
            var commentService = new CommentService(userId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        //[HttpPost]
        //[Route("api/Transaction/PostCommentByPostId/{id}")]
        public IHttpActionResult Post(CommentCreate comment) //removed "[FromUri] int id, "
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Post post = _context.Post.Find(id);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            //_context.Comment.Add(comment);

            return Ok();
        }
    }
}
