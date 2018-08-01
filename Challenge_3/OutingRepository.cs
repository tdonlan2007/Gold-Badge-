using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
	public class OutingRepository
	{
		private List<Outing> _outingList = new List<Outing>();
		
		public List<Outing> GetList()
		{
			return _outingList;
		}

		public void UpdateList(Outing outing)
		{
			_outingList.Add(outing);
		}

		public double CostOfAllOutings()
		{
			double sum = 0;

			foreach (Outing outing in _outingList)
			{
				sum += outing.TotalCost;
			}

			return sum;
		}

		public double CostOfOutingsByType(Event type)
		{
			double sum = 0;

			List<Outing> outingsByType = _outingList.FindAll(x => x.EventType == type);

			foreach(Outing outing in outingsByType)
			{
				sum += outing.TotalCost;
			}

			return sum;
		}
	}
}
