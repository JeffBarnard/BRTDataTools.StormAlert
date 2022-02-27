using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPDataTools.StormAlert.Services
{
	/// <summary>
	/// Barometer service. We don't want to constantly read data and consume CPU/Battery, so this
	/// service will automatically sleep and wake itself occasionally
	/// </summary>
    public class BarometerService
    {
		public static double SeaLevelPressure = 1013.25;

		private bool _paused = false;
		private double _pressureInHectopascals = default;

		public Action<double> ValueChanged { get; set; }

		public BarometerService()
		{
			// We don't require a high sensor speed because we're measuring
			// changes over a long period of time
			try
			{
				Microsoft.Maui.Essentials.Barometer.Start(SensorSpeed.UI);
				Microsoft.Maui.Essentials.Barometer.ReadingChanged += Barometer_ReadingChanged;
			}
            catch (NotSupportedException)
            {
				DebugWin();
			}
		}
		            
		private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
		{
			if (e.Reading.PressureInHectopascals != _pressureInHectopascals)
			{
				// The sensor is very accurate, we don't need the precision, so let's round to 1 decimal place
				_pressureInHectopascals = Math.Round(e.Reading.PressureInHectopascals, 1);

				// Raise notification delegate
				ValueChanged(_pressureInHectopascals);
			}
		}

		private void DebugWin()
		{
			#if DEBUG
			Task.Run(() =>
			{
				for (int i = 1050; i > 900; i--)
				{
					SpinWait.SpinUntil(() => false, 100);
					Barometer_ReadingChanged(null, new BarometerChangedEventArgs(new BarometerData(i)));
				}
			});
			#endif
		}
	}
}
