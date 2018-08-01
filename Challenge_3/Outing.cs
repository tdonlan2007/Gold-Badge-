using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
	public enum Event
	{
		Golf, Bowling, AmusementPark, Concert, Undefined
	}

	public class Outing
	{
		//fields


		//properties
		public Event EventType { get; set; }
		public int NumberOfPeople { get; set; }
		public DateTime DateOfEvent { get; set; }
		public double CostPerPerson { get; set; }
		public double TotalCost { get; set; }

		//constructors
		public Outing(Event eventType, int numPeople, DateTime date, double cost, double totalCost)
		{
			EventType = eventType;
			NumberOfPeople = numPeople;
			DateOfEvent = date;
			CostPerPerson = cost;
			TotalCost = totalCost;
		}

		//override methods
		public override string ToString()
		{
			return $"{EventType}\t\t{NumberOfPeople}\t\t{DateOfEvent.ToShortDateString()}\t\t" +
				$"${CostPerPerson}\t\t${TotalCost}";
		}
	}
}
