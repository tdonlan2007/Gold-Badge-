using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
	public class ClaimRepository
	{
		private List<Claim> _claimsList = new List<Claim>()
		{
			new Claim(1, 400.00, "CrashOn465", DateTime.Parse("4/25/2018"), DateTime.Parse("4/27/18"), ClaimType.Car),
			new Claim(2, 4000.00, "HouseFire", DateTime.Parse("4/26/18"), DateTime.Parse("4/28/18"), ClaimType.Home),
			new Claim(3, 4.00, "StolenFood", DateTime.Parse("4/25/18"), DateTime.Parse("7/01/18"), ClaimType.Theft)
		};


		public List<Claim> GetList()
		{
			return _claimsList;
		}

		public void AddClaim(Claim claim)
		{
			_claimsList.Add(claim);
		}

		public Claim GetFirstItem()
		{
			return _claimsList[0];
		}

		public void RemoveFirstItem()
		{
			_claimsList.Remove(_claimsList[0]);
		}

		public bool VerifyIntResponse(int maxNum, int input)
		{
			if (maxNum < input || input < 0)
				return false;
			else
				return true;
		}
	}
}
