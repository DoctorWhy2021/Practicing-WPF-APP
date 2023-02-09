using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Practicing_WPF_APP.Core;

public static class APIHelper
{
    public static HttpClient APIClient { get; set; }

    public static void InitializeClient()
    {
        APIClient = new HttpClient();
        APIClient.DefaultRequestHeaders.Accept.Clear();
        APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}