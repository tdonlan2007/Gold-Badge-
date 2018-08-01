using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
	public enum ClaimType
	{
		Car, Home, Theft, Undefined
	}
	public class Claim
	{
		public int ClaimID { get; set; }
		public double ClaimAmount { get; set; }
		public string Description { get; set; }
		public bool IsValid => DateOfClaim.Subtract(DateOfAccident).Days <= 30;
		public DateTime DateOfAccident { get; set; }
		public DateTime DateOfClaim { get; set; }
		public ClaimType ClaimClass { get; set; }

		public Claim(int claimID, double claimAmount, string desc, DateTime date, DateTime dateOfClaim, ClaimType claimClass)
		{
			ClaimID = claimID;
			ClaimAmount = claimAmount;
			Description = desc;
			DateOfAccident = date;
			DateOfClaim = dateOfClaim;
			ClaimClass = claimClass;
		}

		public override string ToString() => $"{ClaimID}\t\t{ClaimClass}\t\t{Description}" +
			$"\t\t${ClaimAmount}\t\t{DateOfAccident.ToShortDateString()}\t\t{DateOfClaim.ToShortDateString()}" +
			$"\t\t{IsValid}";
	}
}
