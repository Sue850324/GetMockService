using GetClientIP.Interface;
using System.Web;

namespace GetClientIP.Service
{
    public class GetIPService : IGetIPService
    {
        public string GetIP()
        {
            HttpContext context = HttpContext.Current;
            string clientIP = "";

            if (context.Request.ServerVariables["HTTP_VIA"] == null)
            {
                clientIP = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else
            {
                clientIP = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }

            clientIP = clientIP.Replace("::1", "127.0.0.1");

            return clientIP;
        }

    }
}
