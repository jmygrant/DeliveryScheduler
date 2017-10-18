using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySchedule
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Create Vehicles
			List<Vehicle> vehicleList = CreateVehicles(2);
			List<Delivery> deliveryList = CreateDelivery(5, vehicleList);

			//Create delivery schedule.
			Console.WriteLine("\t\t\t\tDelivery Schedule");
			
			for(int outerCount =0; outerCount<vehicleList.Count; outerCount++)
			{
				Console.WriteLine(string.Format("Vehicle {0}", outerCount));
				int vehicleRate = vehicleList[outerCount].RateOfVehicle;

				for(int innerCount =0; innerCount<deliveryList.Count; innerCount++)
				{
					int innerVehicleRate = deliveryList[innerCount].RateOfVehicle;
					int distance = (innerCount + 5) * 10;

					if (innerVehicleRate == vehicleRate)
					{
						Console.WriteLine(
							string.Format("Delivery: {0} \t Vehicle Rate: {1} \t Distance: {2} \t Departure Time: {3} \t Arrival Time (in hours): {4} \t Unique Id: {5}",
							innerCount + 1, innerVehicleRate, distance,
							deliveryList[innerCount].DepartureTime.TravelTimeValue.ToString(),
							deliveryList[innerCount].CalculateTravelTime(distance),
							deliveryList[innerCount].UniqueTrackingNumber));
					}
				}
				Console.WriteLine("");
			}

			Console.ReadLine();
		}

		public static List<Vehicle> CreateVehicles(int numberOfVehicles)
		{
			List<Vehicle> vehicleList = new List<Vehicle>();

			for(int count = 0; count < numberOfVehicles; count++)
			{
				Vehicle newVehicle = new Vehicle(25 + count * 5);
				vehicleList.Add(newVehicle);
			}

			return vehicleList;
		}

		public static List<Delivery> CreateDelivery(int numberOfDelivery, List<Vehicle> vehicleList)
		{
			List<Delivery> packageList = new List<Delivery>();

			for(int count =0; count<numberOfDelivery; count++)
			{
				int vehicleIndex = count % vehicleList.Count == 0 ? 0 : 1;

				TravelTime newDepartTime = new TravelTime(count + 10 + vehicleIndex,
					count + 10 + vehicleIndex * 2, count + 10 + vehicleIndex * 3);

				Delivery newDelivery = new Delivery(newDepartTime, vehicleList[vehicleIndex]);
				packageList.Add(newDelivery);
			}

			return packageList;
		}
	}
}
