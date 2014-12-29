using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UrlKatana.Business.Services;
using UrlKatana.Domain;
using UrlKatana.WebApp.Controllers.ClientData;

namespace UrlKatana.WebApp.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        ITransformedUrlService service;

        public UrlController(ITransformedUrlService service)
        {
            this.service = service;
        }     

        [Route("{shortUrl}")]
        [HttpGet]
        public HttpResponseMessage Get(string shortUrl)
        {
            try
            {                
                TransformedUrl transformedUrl = service.GetTransformedUrl(shortUrl);

                var result = new UrlData
                {
                    ShortUrl = shortUrl,
                    LongUrl = transformedUrl.LongUrl
                };

                var response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("")]
        [ResponseType(typeof(UrlData))]
        [HttpPost]
        public UrlData Post([FromBody]UrlData data)
        {
            var shortUrl = service.GetShortUrl(data.LongUrl);
            var result = new UrlData
            {
                LongUrl = data.LongUrl,
                ShortUrl = shortUrl
            };

            return result;
        }
    }
}
