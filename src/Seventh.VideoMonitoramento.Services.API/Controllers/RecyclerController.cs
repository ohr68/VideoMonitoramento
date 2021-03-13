using Hangfire;
using Hangfire.Storage;
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

            IMonitoringApi monitoring = JobStorage.Current.GetMonitoringApi();
            long backgroundJobCount = monitoring.EnqueuedCount("recycler");
            var status = backgroundJobCount == 0 ? "not running" : "running";
            httpStatusCode = HttpStatusCode.OK;

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, new { status = status });
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

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }


    }
}
