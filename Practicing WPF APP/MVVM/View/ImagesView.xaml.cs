using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Practicing_WPF_APP.MVVM.Model;

namespace Practicing_WPF_APP.MVVM.View;

public partial class ImagesView : UserControl
{
    public ImagesView()
    {
        InitializeComponent();
        nextButton.IsEnabled = false;
    }
    
    private int maxNumber = 0;
    private int currentNumber = 0;
    private async Task LoadImage(int imageNumber = 0)
    {
        var comic = await ComicProcessor.LoadComic(imageNumber);
        if (imageNumber == 0)
        {
            maxNumber = comic.Num;
        }

        currentNumber = comic.Num;

        var uriSource = new Uri(comic.Img, UriKind.Absolute);
        comicImage.Source = new BitmapImage(uriSource);
    }

    private async void ImagesView_OnLoaded(object sender, RoutedEventArgs e)
    {
        await LoadImage();
    }

    private async void PreviousButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentNumber > 1)
        {
            currentNumber--;
            nextButton.IsEnabled = true;
            await LoadImage(currentNumber);

            if (currentNumber == 1)
            {
                previousButton.IsEnabled = false;
            }
        }
    }

    private async void NextButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentNumber < maxNumber)
        {
            currentNumber++;
            previousButton.IsEnabled = true;
            await LoadImage(currentNumber);
            if (currentNumber == maxNumber)
            {
                nextButton.IsEnabled = false;
            }
        }
    }
}