using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tennis.App
{
    public static class ApiHelper
    {
        public static HttpClient apiClient { get; private set; }

        public static void InitiliateClient()
        {
            apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Clear();
        }
    }
}
