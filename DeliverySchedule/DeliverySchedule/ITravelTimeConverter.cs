using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySchedule
{
	public interface ITravelTimeConverter
	{
		double GetTimeInHours();
		double ConvertSecondsToHours(int seconds);
		double ConvertMinutesToHours(int hours);
	}
}
