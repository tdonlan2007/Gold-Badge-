using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
	public enum Event
	{
		Fishing, Hunting, Trapping, Hiking, Undefined
	}

	public class Outing
	{
		
		public Event EventType { get; set; }
		public int NumberOfPeople { get; set; }
		public DateTime DateOfEvent { get; set; }
		public double CostPerPerson { get; set; }
		public double TotalCost { get; set; }

	
		public Outing(Event eventType, int numPeople, DateTime date, double cost, double totalCost)
		{
			EventType = eventType;
			NumberOfPeople = numPeople;
			DateOfEvent = date;
			CostPerPerson = cost;
			TotalCost = totalCost;
		}

		
		public override string ToString()
		{
			return $"{EventType}\t\t{NumberOfPeople}\t\t{DateOfEvent.ToShortDateString()}\t\t" +
				$"${CostPerPerson}\t\t${TotalCost}";
		}
	}
}
