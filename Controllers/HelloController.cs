using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.OleDb;

namespace Test_API.Controllers
{
    // GET: Hello
    [RoutePrefix("api/hello")]
    public class HelloController : ApiController
    {
        // GET /api/hello
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody] HelloRequest request)
        {

            string appVersion = "";
            if (Request.Headers.Contains("X-App-Version"))
            {
                appVersion = Request.Headers.GetValues("X-App-Version").FirstOrDefault();
            }

                var payload = new
            {
                message = "Ciao da Web API 2",
                timeUtc = DateTime.UtcNow
            };
            return Ok(new HelloDto { Message = "Versione: " + appVersion + " - PAR1: " + request.par1 + " PAR2: " + request.par2, TimeUtc = DateTime.UtcNow });

        }
    }

    public class HelloRequest
    {
        public string par1 { get; set; }
        public string par2 { get; set; }
    }

    public class HelloDto
    {
        public string Message { get; set; }
        public DateTime TimeUtc { get; set; }
    }
}