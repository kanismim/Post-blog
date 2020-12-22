using PostBlog.Models;
using PostBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostBlog.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        PostRepository postrepo = new PostRepository();
        CommentRepository comRepo = new CommentRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(postrepo.GetAll());
        }

        [Route("{id}", Name ="GetPostById")]
        public IHttpActionResult Get(int id)
        {

            var postview = postrepo.Get(id);
            if (postview == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(postrepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Post p)
        {
            //p.UserId=
            postrepo.Insert(p);
            string uri = Url.Link("GetPostById", new { id = p.PostId });
            return Created(uri, p);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Post p)
        {
            p.PostId = id;
           postrepo.Update(p);
            return Ok(p);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
           // var pr = postrepo.Get(id);
            postrepo.Delete(id);
           //var comm= comRepo.GetCommentByPost(pr.PostId);
           // int i= comm.
           // comRepo.Delete(i.);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/comments", Name = "GetComment")]
        public IHttpActionResult GetComments(int id)
        {
            return Ok(comRepo.GetCommentByPost(id));
        }

        [Route("{id}/comments/{i}", Name = "GetCommentById")]
        public IHttpActionResult GetComments(int id,int i)
        {

            var comview = comRepo.GetCommentID(id,i);
            if (comview == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(comRepo.GetCommentID(id, i));
        }

        [Route("{id}/comments")]
        public IHttpActionResult PostComment(Comment comment)
        {
            comRepo.Insert(comment);
           
            return Created("{id}/comments", comment);
        }

        [Route("{id}/comments/{i}")]
        public IHttpActionResult PutComment([FromUri]int i, [FromBody]Comment comment)
        {
            comment.CommentId = i;
            comRepo.Update(comment);
            return Ok(comment);
        }
    }
}
