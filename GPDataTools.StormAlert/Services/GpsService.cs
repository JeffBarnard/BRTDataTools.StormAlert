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
	public class GpsService
    {
		private bool _paused = false;
		
		public Action<double> ValueChanged { get; set; }

		public GpsService()
		{
			// We don't require a high sensor speed because we're measuring
			// changes over a long period of time
			try
			{
				GetLocation();
			}
            catch (NotSupportedException)
            {
				// Log
			}
		}

		private async void GetLocation()
        {
			//var last = await Microsoft.Maui.Essentials.Geolocation.GetLastKnownLocationAsync();
		}

	}
}
