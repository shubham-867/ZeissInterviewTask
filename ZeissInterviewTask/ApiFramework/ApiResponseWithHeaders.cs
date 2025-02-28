using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZeissInterviewTask.ApiFramework
{
    public class ApiResponseWithHeaders
    {
        public ApiResponseWithHeaders(HttpStatusCode status, string content, HttpResponseHeaders headers)
        {
            StatusCode = status;
            Headers = headers;
            Content = content;
        }

        public HttpStatusCode StatusCode { get; private set; }
        public HttpResponseHeaders Headers { get; private set; }
        public string Content { get; set; }
    }
}
