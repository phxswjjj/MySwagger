using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySwagger.Controllers
{
    [RoutePrefix("api/Disp")]
    public class DispController : ApiController
    {
        static readonly TimeSpan Expired = new TimeSpan(0, 0, 3);

        [Route("MoveIn")]
        [HttpGet]
        public IHttpActionResult MoveIn(string lotId)
        {
            var redis = ConnectionMultiplexer.Connect("redis.local:6379");
            var db = redis.GetDatabase();
            var isSuccess = db.StringSet($"DISP:LOT:{lotId}", Environment.MachineName, 
                expiry: Expired, when: When.NotExists);
            if (isSuccess)
                return Ok();
            else
                return InternalServerError();
        }
    }
}