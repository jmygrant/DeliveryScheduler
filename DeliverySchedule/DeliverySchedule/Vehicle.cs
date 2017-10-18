using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySchedule
{
	public class Vehicle : TravelTimeCalcBaseClass
	{
		private int _rateOfVehicle;

		/// <summary>
		/// Gets the current value that the rate is set to.
		/// </summary>
		public int RateOfVehicle
		{
			get
			{
				return _rateOfVehicle;
			}
		}

		public Vehicle()
		{
			//When a vehicle is created be default we assign it a rate in the range of 25-55 mph.
			SetRateOfVehicle(25);
		}

		public Vehicle(int rate)
		{
			SetRateOfVehicle(rate);
		}

		/// <summary>
		/// This sets the rate that the vechicle is moving. I set the rabnge of the vehicle to be
		/// between 25 and 55. I assumed that the delivery was ready to be delivered and thus
		/// speeds over 55 are not part of the time calculation for delivery. I also made it so that
		/// the only values that get accepted must be divisible by 5 since 26 or 27 are not standardized
		/// speed limits.
		/// </summary>
		/// <param name="newRate"></param>
		/// <returns>Returns a boolean if the set was sucessful.</returns>
		public bool SetRateOfVehicle(int newRate)
		{
			if (newRate < 25 || newRate > 55)
			{
				return false;
			}

			if (newRate >= 25 && newRate <= 55 && newRate % 5 == 0)
			{
				_rateOfVehicle = newRate;
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// Implements the time calculation using distance. I do depend on the 
		/// vehicle rate or speed to be set before this calculate distance is used.
		/// </summary>
		/// <param name="distance"></param>
		/// <returns>Returns the time in hours it takes to travel the distance input.
		/// Returns -1 if the distance is negative.</returns>
		public override double CalculateTravelTime(int distance)
		{
			if(distance < 0)
			{
				return -1;
			}

			double travelTime = Math.Round((double)(distance) / _rateOfVehicle, 2);
			return travelTime;
		}
	}
}
