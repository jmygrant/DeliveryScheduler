using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySchedule
{
	public abstract class TravelTimeCalcBaseClass
	{
		/// <summary>
		/// An Abstract Method that should be overloaded to calculate the time
		/// it would take to travel a specific distance.
		/// </summary>
		/// <param name="distance"></param>
		/// <returns></returns>
		public abstract double CalculateTravelTime(int distance);
	}
}
