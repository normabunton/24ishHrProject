using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ReplyServices
    {

        public bool CreateReply(Reply model)
        {
            var entity =
                new Reply()
                {
                    User = model.User,
                    ReplyText = model.ReplyText
                };
            using(var content = new ApplicationDbContext())
            {
                Reply reply = content.Reply.Add(entity);
                return content.SaveChanges() == 1;
            }
        }


    }
}
