using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace calumet.Controllers
{
    public abstract class BaseController : ApiController
    {
        public string BaseLink
        {
            get
            {
                var link = "http://test";
                if (Url != null && Url.Request != null)
                {
                    var request = Url.Request;
                    link = request.RequestUri.AbsolutePath;
                }
                return link;
            }
        }
    }
}