using Seventh.VideoMonitoramento.Application.Interfaces;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.WebAPI.Filters;
using Seventh.VideoMonitoramento.WebAPI.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seventh.VideoMonitoramento.WebAPI.Controllers
{
    [RoutePrefix("api/servers")]
    public class ServerController : ApiController
    {
        private readonly IServerAppService _serverAppService;

        public ServerController(IServerAppService serverAppService)
        {
            _serverAppService = serverAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> Get()
        {
            HttpStatusCode httpStatusCode;
            object servers = new object();

            try
            {
                servers = _serverAppService.GetAll();

                if (servers == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                    httpStatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, servers);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpGet]
        [Route("{serverId:guid}")]
        public Task<HttpResponseMessage> Get([FromUri] Guid serverId)
        {
            HttpStatusCode httpStatusCode;
            object server = new object();

            try
            {
                server = _serverAppService.GetById(serverId);

                if (server == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                    httpStatusCode = HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, server);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpGet]
        [Route("{serverId:guid}/available")]
        public Task<HttpResponseMessage> CheckServerAvailability([FromUri] Guid serverId)
        {
            HttpStatusCode httpStatusCode;
            object serverStatus = new object();

            try
            {
                var server = _serverAppService.CheckServerAvailability(serverId);
                
                serverStatus = new { ip = server.Address.ToString(), status = IPStatusText.GetStatusString(server.Status) };

                httpStatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, serverStatus);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }

        [HttpPost]
        [Route("")]
        [ValidateModel]
        public Task<HttpResponseMessage> Post([FromBody] ServerViewModel server)
        {
            HttpStatusCode httpStatusCode;
            object createdServer = new object();

            try
            {
                createdServer = _serverAppService.Create(server);
                httpStatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }


            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, createdServer);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }


        [HttpDelete]
        [Route("{serverId:guid}")]
        public Task<HttpResponseMessage> Delete([FromUri] Guid serverId)
        {
            HttpStatusCode httpStatusCode;
            object serverToBeDeleted = new object();

            try
            {
                serverToBeDeleted = _serverAppService.GetById(serverId);

                if (serverToBeDeleted == null)
                    httpStatusCode = HttpStatusCode.NotFound;
                else
                {
                    _serverAppService.Remove(serverId);
                    httpStatusCode = HttpStatusCode.OK;
                }
            }catch(Exception e)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(httpStatusCode, serverToBeDeleted);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(httpResponseMessage);
            return tsc.Task;
        }
    }
}
