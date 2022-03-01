using GetClientIP.ActionFilter;
using GetClientIP.Interface;

namespace GetClientIP.Service
{
    [MockService]
    public class GetIPMockService : IGetIPService
    {
        public string GetIP()
        {
            string result = "115.11.123.111";

            return result;
        }
    }
}