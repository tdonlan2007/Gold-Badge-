using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
	class ProgramUI
	{
		ClaimRepository claimRepo = new ClaimRepository();

		public void Run()
		{
			InitialPrompt();
		}

		private void InitialPrompt()
		{
			Console.Clear();
			Console.WriteLine("Choose Menu Item:\n1. See All Claims\n2. Take Care of Next Claim\n3. Enter New Claim\n4. Exit");
			string inputStr = Console.ReadLine();
			bool inputBool = int.TryParse(inputStr, out int input);
			if (claimRepo.VerifyIntResponse(4, input) == false || inputBool == false)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				InitialPrompt();
			}

			switch(input)
			{
				case 1:
					AllClaimsList();
					break;
				case 2:
					NextClaimInQueue();
					break;
				case 3:
					EnterNewClaim();
					break;
				case 4:
					UIExit();
					break;
			}
		}

		private void AllClaimsList()
		{
			Console.Clear();
			Console.WriteLine("ClaimID\t\tType\t\tDescription\t\tAmount\t\tDateOfAccident\t\tDateOfClaim\t\tIsValid\n");
			foreach(Claim claim in claimRepo.GetList())
			{
				Console.WriteLine(claim);
			}
			Console.ReadKey();
			InitialPrompt();
		}

		private void NextClaimInQueue()
		{
			Console.Clear();
			Console.WriteLine("ClaimID\t\tType\t\tDescription\t\tAmount\t\tDateOfAccident\t\tDateOfClaim\t\tIsValid\n");
			Console.WriteLine(claimRepo.GetFirstItem());
			Console.Write("\nWould you like to take care of this claim now? (Y/N) ");
			string input = Console.ReadLine();
			if (input == "Y" || input == "y")
			{
				claimRepo.RemoveFirstItem();
				Console.Clear();
				Console.WriteLine("Claim Pulled");
				Console.ReadKey();
				InitialPrompt();
			}
			else
				InitialPrompt();
		}

		private void EnterNewClaim()
		{
			Console.Clear();
			Console.Write("Enter Claim ID: ");
			string idStr = Console.ReadLine();

			bool idBool = int.TryParse(idStr, out int ID);
			if(idBool == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response");
				Console.ReadKey();
				EnterNewClaim();
			}

			Console.Write("Enter Claim Type: ");
			string type = Console.ReadLine();

			ClaimType claimType = ClaimType.Undefined;

			switch (type)
			{
				case "Car":
					claimType = ClaimType.Car;
					break;
				case "Home":
					claimType = ClaimType.Home;
					break;
				case "Theft":
					claimType = ClaimType.Theft;
					break;
				default:
					claimType = ClaimType.Undefined;
					break;
			}

			Console.Write("Enter Claim Description: ");
			string desc = Console.ReadLine();

			Console.Write("Enter Amount: ");
			string amountStr = Console.ReadLine();
			bool amtBool = double.TryParse(amountStr, out double amount);
			if(amtBool == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Answer");
				Console.ReadKey();
				EnterNewClaim();
			}

			Console.Write("Date of Accident: ");
			string dateAcc = Console.ReadLine();

			DateTime dateAccident = DateTime.Parse(dateAcc);

			Console.Write("Date of Claim: ");
			string dateCl = Console.ReadLine();

			DateTime dateClaim = DateTime.Parse(dateCl);

			Claim newClaim = new Claim(ID, amount, desc, dateAccident, dateClaim, claimType);

			if(newClaim.IsValid == true)
				Console.WriteLine("This Claim is Valid");
			else
				Console.WriteLine("This Claim is not Valid");

			Console.ReadKey();

			claimRepo.AddClaim(newClaim);

			Console.Clear();
			Console.Write("Claim Added\nAdd Another? (Y/N) ");
			string input = Console.ReadLine();

			if(input == "y" || input == "Y")
			{
				EnterNewClaim();
			}

			InitialPrompt();
		}

		private void UIExit()
		{

		}
	}
}
