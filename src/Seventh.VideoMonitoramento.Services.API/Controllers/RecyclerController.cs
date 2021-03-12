using Hangfire;
using Seventh.VideoMonitoramento.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seventh.VideoMonitoramento.Services.API.Controllers
{
    [RoutePrefix("api/recycler")]
    public class RecyclerController : ApiController
    {
        private readonly IVideoAppService videoAppService;

        [HttpGet]
        [Route("status")]
        public Task<HttpResponseMessage> Get()
        {
            HttpStatusCode httpStatusCode;

            httpStatusCode = HttpStatusCode.OK;

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, new { status = "not running" });
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpGet]
        [Route("process/{days:int}")]
        public Task<HttpResponseMessage> Get([FromUri] int days)
        {
            HttpStatusCode httpStatusCode;

            var queueId = BackgroundJob.Enqueue<IVideoAppService>(video =>
                    video.Recycle(days));

            httpStatusCode = HttpStatusCode.Accepted;

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, queueId);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }


    }
}
