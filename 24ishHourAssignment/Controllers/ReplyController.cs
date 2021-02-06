using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace _24ishHourAssignment.Controllers
{
    [System.Web.Http.Authorize]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new ReplyService(userId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var comments = replyService.GetReplys();
            return Ok(comments);
        }

 
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();


            return Ok();
        }
    }
}
