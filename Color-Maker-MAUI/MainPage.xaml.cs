using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Color_Maker_MAUI;

public partial class MainPage : ContentPage
{
    bool isRandom = false;
    public MainPage()
    {
        InitializeComponent();
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if(!isRandom)
        {
            var red = sliderRed.Value;
            var green = sliderGreen.Value;
            var blue = sliderBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            setColor(color);
        }
    }

    //set color picker method
    private void setColor(Color color)
    {
        Container.BackgroundColor = color;
        btnRandom.BackgroundColor = color;
        lblColorHex.Text = color.ToHex();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(lblColorHex.Text);
        var toast = Toast.Make("Color Copied", ToastDuration.Short, 13);
        await toast.Show();
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        Random random = new Random();
        var color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

        sliderBlue.Value = color.Blue;
        sliderRed.Value = color.Red;
        sliderGreen.Value = color.Green;

        setColor(color);
        isRandom = false;
    }
}

