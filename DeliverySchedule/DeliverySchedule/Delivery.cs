using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySchedule
{
	public class Delivery : TravelTimeCalcBaseClass
	{
		private TravelTime _departureTime;
		public TravelTime DepartureTime
		{
			get
			{
				return _departureTime;
			}
		}

		private string _uniqueTrackingNumber;
		public string UniqueTrackingNumber
		{
			get
			{
				return _uniqueTrackingNumber;
			}
		}

		private Vehicle _deliveryVehicle;

		public int RateOfVehicle
		{
			get
			{
				return _deliveryVehicle.RateOfVehicle;
			}
		}

		public Delivery()
		{
			_departureTime = new TravelTime(0, 0, 0);
			_uniqueTrackingNumber = string.Empty;
			_deliveryVehicle = new Vehicle(25);
		}

		public Delivery(TravelTime departureTime, Vehicle vehicle)
		{
			_departureTime = departureTime;
			CreateUniqueTrackingNumber();
			_deliveryVehicle = vehicle;
		}

		public override double  CalculateTravelTime(int distance)
		{
			double vehicleTravelTime = _deliveryVehicle.CalculateTravelTime(distance);
			return Math.Round(DepartureTime.GetTimeInHours() + vehicleTravelTime, 2);
		}

		public void SetDepartureTime(TravelTime timeOfDeparture)
		{
			if (timeOfDeparture != null)
			{
				_departureTime = timeOfDeparture;
			}
		}

		private void CreateUniqueTrackingNumber()
		{
			_uniqueTrackingNumber =  Guid.NewGuid().ToString();
		}
	}
}
