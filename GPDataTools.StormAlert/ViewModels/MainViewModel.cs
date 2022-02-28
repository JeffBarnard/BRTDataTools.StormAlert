using GPDataTools.StormAlert.Services;
using MvvmHelpers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPDataTools.StormAlert.ViewModels;

/// <summary>
/// Presentation ViewModel
/// 
/// Fody property change weaver
/// 
/// </summary>
[AddINotifyPropertyChangedInterface]
public class MainViewModel : BaseViewModel
{
    private BarometerService _barometerService;
    private GpsService _gpsService;

    #region Properties

    public string CounterLabel { get; set; }
    public string CounterValue { get; set; }
    public string StatusLabel { get; set; }
    public ImageSource TrendImage { get; set; }
    public GraphicsDrawable Drawable { get; set; }

    public List<PressureChartData> PressureHistory { get; }

    public Command TestAlertCommand { get; set; }

    #endregion  

    public MainViewModel(BarometerService barometerService, GpsService gpsService)
    {
        _barometerService = barometerService;
        _gpsService = gpsService;
        Drawable = new GraphicsDrawable();

        barometerService.ValueChanged = OnUpdatePressureLabel;

        StatusLabel = "Trending...";
        TrendImage = "trendingdown.png";

        
        TestAlertCommand = new Command(() => {

            StatusLabel = "Warning";
            TrendImage = "storm.png";

            // Notification test
            Services.ServiceProvider.GetService<INotificationService>()
                    ?.ShowNotification("Storm Alert", "An incoming storm front has been detected! 😲");
        });

        float universeAdjust = 30;
        float curPressure = 1013 + universeAdjust;

        PressureHistory = new List<PressureChartData> {
           new PressureChartData(1, curPressure - 1000),
           new PressureChartData(2, curPressure - 1001),
           new PressureChartData(3, curPressure - 1002),
           new PressureChartData(4, curPressure - 1003),
           new PressureChartData(5, curPressure - 1003),
           new PressureChartData(6, curPressure - 1004),
           new PressureChartData(7, curPressure - 1006),
           
           new PressureChartData(8, curPressure - 1006),
           new PressureChartData(9, curPressure - 1006),
           new PressureChartData(10, curPressure - 1005),
           new PressureChartData(11, curPressure - 1004),
           new PressureChartData(12, curPressure - 1003),
           new PressureChartData(13, curPressure - 1003),
           new PressureChartData(14, curPressure - 1002),
           new PressureChartData(15, curPressure - 1002),
           new PressureChartData(16, curPressure - 1004),
           new PressureChartData(17, curPressure - 1005),
           new PressureChartData(18, curPressure - 1006),
           new PressureChartData(19, curPressure - 1007),
           new PressureChartData(20, curPressure - 1007),
           new PressureChartData(21, curPressure - 1008),
           new PressureChartData(22, curPressure - 1008),
           new PressureChartData(23, curPressure - 1009),
           new PressureChartData(24, curPressure - 1010),
       };
    }

    /// <summary>
    /// Delegate event when sensor value changes
    /// </summary>
    /// <param name="pressure"></param>
    private void OnUpdatePressureLabel(double pressure)
    {
        CounterValue = $"{pressure}";
        //SemanticScreenReader.Announce(CounterLabel);

        Drawable.Increment(1);
    }
}
