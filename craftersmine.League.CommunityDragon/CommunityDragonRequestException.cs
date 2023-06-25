using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public class CommunityDragonRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public CommunityDragonRequestException(HttpStatusCode code)
        {
            StatusCode = code;
        }

        public CommunityDragonRequestException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }

        public CommunityDragonRequestException(HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            StatusCode = code;
        }
    }
}
