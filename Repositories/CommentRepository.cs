using PostBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostBlog.Repositories
{
    public class CommentRepository: Repository<Comment>
    {
        public List<Comment> GetCommentByPost(int id)
        {
            return this.GetAll().Where(x => x.PostId == id).ToList();
        }

        public List<Comment> GetCommentID(int id,int i)
        {
            return this.GetAll().Where(x => x.PostId == id && x.CommentId==i).ToList();
        }
    }
}