using System;
using System.Net.Http;
using System.Threading.Tasks;
using Practicing_WPF_APP.Core;

namespace Practicing_WPF_APP.MVVM.Model;

public class SunProcessor
{
    public static async Task<SunModel> LoadSunInfo()
    {
        string url = "https://api.sunrise-sunset.org/json?lat=48.548555&lng=35.837018&date=today";


        using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                return result.Results;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}