using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using Practicing_WPF_APP.Core;
using Practicing_WPF_APP.MVVM.Model;

namespace Practicing_WPF_APP.MVVM.ViewModel;

public class CoinsViewModel: ObservableObject
{

    public ObservableCollection<ItemCoinModel> CoinsList { get; set; }

    public RelayCommand CoinsListCommand { get; set; }

    private async Task LoadCoin()
    {
        var coins = await CoinProcessor.LoadCoinsInfo();

        foreach (var coin in coins.Coins)
        {
            CoinsList.Add(coin.Item);
        }
    }

    public CoinsViewModel()
    {
        CoinsList = new ObservableCollection<ItemCoinModel>();
        LoadCoin();
        CoinsListCommand = new RelayCommand(o =>
        {
            
        });

    }
}