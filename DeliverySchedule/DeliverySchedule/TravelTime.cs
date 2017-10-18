using System;

namespace DeliverySchedule
{
	public class TravelTime : ITravelTimeConverter
	{
		private TimeSpan _travelTime;

		public TimeSpan TravelTimeValue
		{
			get { return _travelTime; }
		}

		public TravelTime()
		{
			_travelTime = new TimeSpan();
		}

		public TravelTime(int hours, int minutes, int seconds)
		{
			_travelTime = new TimeSpan();
			setTravelTime(hours, minutes, seconds);
		}

		public void setTravelTime(int hours, int minutes, int seconds)
		{
			bool verifyHours = hours >= 0 && hours < 24;
			bool verifyMinutes = minutes >= 0 && minutes <= 60;
			bool verifySeconds = seconds >= 0 && seconds <= 60;

			if ( verifyHours && verifyMinutes && verifySeconds)
			{
				_travelTime = new TimeSpan(hours, minutes, seconds);
			}
		}


		/// <summary>
		/// Implements the interfaces to get the time represented as hours.
		/// </summary>
		/// <returns></returns>
		public double GetTimeInHours()
		{
			double secondsToHours = ConvertSecondsToHours(_travelTime.Seconds);

			double minutesToHours = ConvertMinutesToHours(_travelTime.Minutes);

			return _travelTime.Hours + minutesToHours + secondsToHours;
		}

		/// <summary>
		/// Convert the number of seconds to hours
		/// </summary>
		/// <param name="seconds"></param>
		/// <returns></returns>
		public double ConvertSecondsToHours(int seconds)
		{
			return seconds / 3600.0d;
		}

		/// <summary>
		/// Convert the number of minutes to hours.
		/// </summary>
		/// <param name="minutes"></param>
		/// <returns></returns>
		public double ConvertMinutesToHours(int minutes)
		{
			return minutes / 60.0d;
		}
	}
}
