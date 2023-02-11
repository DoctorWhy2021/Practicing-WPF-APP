using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Practicing_WPF_APP.Core;

namespace Practicing_WPF_APP.MVVM.Model;

public class CoinProcessor
{

    public static async Task<CoinsModel> LoadCoinsInfo()
    {
        string url = "https://api.coingecko.com/api/v3/search/trending";

        using (HttpResponseMessage responseMessage = await APIHelper.APIClient.GetAsync(url))
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                CoinsModel coin = await responseMessage.Content.ReadAsAsync<CoinsModel>();

                return coin;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
    }
}