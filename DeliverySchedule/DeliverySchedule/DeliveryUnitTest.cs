using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DeliverySchedule
{
	[TestFixture]
	public class DeliveryUnitTest
	{
		private Delivery _testDelivery;

		public DeliveryUnitTest()
		{
			_testDelivery = new Delivery();
		}

		[TestCase]
		public void TestSetDepartureTime()
		{
			int seconds = 15;
			int minutes = 15;
			int hours = 5;

			TravelTime departTime = new TravelTime(hours, minutes, seconds);
			_testDelivery.SetDepartureTime(departTime);

			Assert.AreEqual(_testDelivery.DepartureTime, departTime);

		}

		[TestCase]
		public void TestCalculateTravelTime()
		{
			Vehicle myVehicle = new Vehicle(35);
			TravelTime packageTime = new TravelTime(16, 45, 56);
			_testDelivery = new Delivery(packageTime, myVehicle);

			double travelTime = _testDelivery.CalculateTravelTime(60);

			Assert.AreEqual(18.48, travelTime);
		}

		[TestCase]
		public void TestCreateUniqueIds()
		{
			Vehicle myVehicle1 = new Vehicle(25);
			TravelTime packageTime1 = new TravelTime(4, 30, 25);
			Delivery firstPackage = new Delivery(packageTime1, myVehicle1);

			Vehicle myVehicle2 = new Vehicle(50);
			TravelTime packageTime2 = new TravelTime(6, 0, 4);
			Delivery secondpackage = new Delivery(packageTime2, myVehicle2);

			Assert.AreNotEqual(firstPackage.UniqueTrackingNumber, secondpackage.UniqueTrackingNumber);
		}
	}
}
