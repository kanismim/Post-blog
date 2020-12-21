using PostBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostBlog.Controllers
{
    [RoutePrefix("api/post")]
    public class PostsController : ApiController
    {
        PostRepository postrepo = new PostRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(postrepo.GetAll());
        }
       
    }
}
