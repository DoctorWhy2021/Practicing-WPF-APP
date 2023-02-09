using System.Windows;
using System.Windows.Controls;
using Practicing_WPF_APP.MVVM.Model;

namespace Practicing_WPF_APP.MVVM.View;

public partial class SunInfoView : UserControl
{
    public SunInfoView()
    {
        InitializeComponent();
    }

    private async void LoadSunInfoBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var sunInfo = await SunProcessor.LoadSunInfo();

        sunriseText.Text = $"Sunrise is at {sunInfo.Sunrise.ToLocalTime().ToShortTimeString()}";
        sunsetText.Text = $"Sunset is at {sunInfo.Sunset.ToLocalTime().ToShortTimeString()}";
    }
}