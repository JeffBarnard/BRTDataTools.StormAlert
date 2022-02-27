using GPDataTools.StormAlert.ViewModels;

namespace GPDataTools.StormAlert;

/// <summary>
/// Presentation only
/// </summary>
public partial class MainPage : ContentPage
{
	// injected dependency
    readonly private MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

		_viewModel = viewModel;
        _viewModel.PropertyChanged += _viewModel_PropertyChanged;
		BindingContext = _viewModel;

		// Allow main activities to start up
		Task.Delay(2000).ContinueWith(task => InitPlatformSensors() );
    }

    private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
		//ChartGraphicsView.Invalidate();
	}


    private void InitPlatformSensors()
    {
#if !DEBUG
		App.Current.Dispatcher.Dispatch(() => {

			try
			{
				Microsoft.Maui.Essentials.Barometer.Start(SensorSpeed.UI);
				Microsoft.Maui.Essentials.Barometer.Stop();
			}
			catch (Microsoft.Maui.Essentials.FeatureNotSupportedException)
			{
				CounterValue.Text = "-";
				StatusLabel.Text = "Your device does not have a Barometer sensor";
				TrendImage.Source = "sensor_off.png";
			}
		});
#endif
	}
}
