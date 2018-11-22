using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taoxue.Training.Website.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsAjax(this HttpRequest request)
        {
            bool result = false;
            var xreq = request.Headers.ContainsKey("X-Requested-With");
            if (xreq)
            {
                result = request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }
            return result;
        }
    }
}
