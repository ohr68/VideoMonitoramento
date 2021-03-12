using Seventh.VideoMonitoramento.Application.Interfaces;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.Services.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seventh.VideoMonitoramento.Services.API.Controllers
{
    [RoutePrefix("api/servers/{serverId:guid}/videos")]
    public class VideoController : ApiController
    {
        private readonly IVideoAppService _videoAppService;

        public VideoController(IVideoAppService videoAppService)
        {
            _videoAppService = videoAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetServerVideos(Guid serverId)
        {
            HttpStatusCode httpStatusCode;
            IEnumerable<VideoViewModel> videos = null;

            try
            {
                videos = _videoAppService.GetAllServerVideos(serverId);

                if (videos == null || videos.Count() == 0)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                    httpStatusCode = HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, videos);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpGet]
        [Route("{videoId:guid}")]
        public Task<HttpResponseMessage> Get(Guid videoId)
        {
            HttpStatusCode httpStatusCode;
            VideoViewModel video = null;

            try
            {
                video = _videoAppService.GetById(videoId);

                if (video == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                    httpStatusCode = HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, video);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpGet]
        [Route("{videoId:guid}/binary")]
        public Task<HttpResponseMessage> DownloadVideoContent(Guid videoId)
        {
            HttpStatusCode httpStatusCode;
            HttpContent content = new ByteArrayContent(new byte[] { });

            try
            {
                var video = _videoAppService.GetById(videoId);

                if (video == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                {
                    content = new ByteArrayContent(video.FileData);
                    httpStatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode);
            httpResponseMessage.Content = content;
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpPost]
        [Route("")]
        [ValidateModel]
        public Task<HttpResponseMessage> Post([FromBody] VideoViewModel video)
        {
            HttpStatusCode httpStatusCode;
            object createdVideo = new object();

            try
            {
                createdVideo = _videoAppService.Create(video);
                httpStatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, createdVideo);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("{videoId:guid}")]
        public Task<HttpResponseMessage> Delete(Guid videoId)
        {
            HttpStatusCode httpStatusCode;
            object videoToBeDeleted = new object();

            try
            {
                videoToBeDeleted = _videoAppService.GetById(videoId);

                if (videoToBeDeleted == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                {
                    _videoAppService.Remove(videoId);
                    httpStatusCode = HttpStatusCode.OK;
                }


            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, videoToBeDeleted);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

    }
}
