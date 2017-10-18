using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DeliverySchedule
{
	[TestFixture]
	public class VehicleUnitTest
	{
		private Vehicle _newVehicle; 
		public VehicleUnitTest()
		{
			_newVehicle = new Vehicle();
		}

		[TestCase]
		public void TestCalculateTravelTime()
		{
			//Test to see if I can Calculate travel time appropiately
			int distance = 25;
			double timeToTravel = _newVehicle.CalculateTravelTime(distance);
			Assert.AreEqual(1.00d, timeToTravel);

			_newVehicle.SetRateOfVehicle(45);
			timeToTravel = _newVehicle.CalculateTravelTime(distance);
			Assert.AreEqual(0.56d, timeToTravel);

			//Test to see what happens if I pass in a distance if zero or a negative distance.
			distance = 0;
			timeToTravel = _newVehicle.CalculateTravelTime(distance);
			Assert.AreEqual(0, timeToTravel);

			distance = -25;
			timeToTravel = _newVehicle.CalculateTravelTime(distance);
			Assert.AreEqual(-1, timeToTravel);

		}

		[TestCase]
		public void TestSetRateOfVehicle()
		{
			int rate = 0;
			bool isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(false, isRateSet);

			rate = 25;
			isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(true, isRateSet);
			Assert.AreEqual(rate, _newVehicle.RateOfVehicle);

			rate = 55;
			isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(true, isRateSet);
			Assert.AreEqual(rate, _newVehicle.RateOfVehicle);

			rate = 56;
			isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(false, isRateSet);

			rate = 65;
			isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(false, isRateSet);

			rate = -25;
			isRateSet = _newVehicle.SetRateOfVehicle(rate);
			Assert.AreEqual(false, isRateSet);
		}
	}
}
