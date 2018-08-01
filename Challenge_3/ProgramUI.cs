using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
	public class ProgramUI
	{
		private List<Outing> _outings = new List<Outing>();
		OutingRepository outingRepo = new OutingRepository();

		public void Run()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			InitialPrompt();
		}

		private void InitialPrompt()
		{
			Console.Clear();
			Console.WriteLine("1. Display List of Outings\n2. Add an Outing\n3. Find Costs for Outings\n4. Exit");
			string input = Console.ReadLine();

			switch (input)
			{
				case "1":
					UIDisplay();
					break;
				case "2":
					UIAddOuting();
					break;
				case "3":
					UICostForOutings();
					break;
				case "4":
					UIExit();
					break;
               
				default:
					Console.Clear();
					Console.WriteLine("Invalid Answer");
					InitialPrompt();
					break;
			}
		}

		private void UIDisplay()
		{
			Console.Clear();
			_outings = outingRepo.GetList();

			if(_outings.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("List is Empty, Please Add an Outing(s)");
				Console.ReadKey();
				InitialPrompt();
			}
			else
			{
				foreach(Outing outing in _outings)
				{
					Console.WriteLine(outing);
				}
				Console.ReadKey();
				InitialPrompt();
			}
		}

		private void UIAddOuting()
		{
			Console.Clear();
			Console.WriteLine("NOTE: Inputs are spelling specific");
			Console.WriteLine("Enter Event Type\n1. Fishing\n2. Hunting\n3. Trapping\n4. Hiking");

			string eventStr = Console.ReadLine();
			bool eventBool = int.TryParse(eventStr, out int evnt);

			if (eventBool == false || evnt > 4 || evnt < 0)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UIAddOuting();
			}

			Event eventType = Event.Undefined;

			switch (evnt)
			{
				case 1:
					eventType = Event.Fishing;
					break;
				case 2:
					eventType = Event.Hunting;
					break;
				case 3:
					eventType = Event.Trapping;
					break;
				case 4:
					eventType = Event.Hiking;
					break;
				default:
					Console.WriteLine("Wrong!!!!");
					Console.ReadKey();
					UIAddOuting();
					break;
			}

			Console.Write("Enter Number of People that went to the Event: ");
			string numPeopleStr = Console.ReadLine();

			bool numBool = int.TryParse(numPeopleStr, out int numPeople);
			if(numBool == false)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UIAddOuting();
			}

			Console.Write("Enter Date of the Event (DD/MM/YY): ");
			string date = Console.ReadLine();
		
			DateTime eventDate = DateTime.Parse(date);

			Console.Write("Enter Cost Per Person: ");
			string costPerPersonStr = Console.ReadLine();

			bool costBool = double.TryParse(costPerPersonStr, out double costPerPerson);
			if(costBool == false)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UIAddOuting();
			}

			Console.Write("Enter Total Cost: ");
			string totalCostStr = Console.ReadLine();

			bool totalBool = double.TryParse(totalCostStr, out double totalCost);
			if (totalBool == false)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UIAddOuting();
			}

			Outing newOuting = new Outing(eventType, numPeople, eventDate, costPerPerson, totalCost);
			outingRepo.UpdateList(newOuting);

			Console.Clear();
			Console.WriteLine("Added To Events");
			Console.ReadKey();
			Console.Clear();
			Console.Write("Add Another Event? (Y/N) ");
			string input = Console.ReadLine();

			if (input == "Y" || input == "y")
				UIAddOuting();
			else
				InitialPrompt();

		}

		private void UICostForOutings()
		{
			Console.Clear();
			Console.WriteLine("1. All Outings\n2. Outings by Type");
			string inputStr = Console.ReadLine();
			bool inputBool = int.TryParse(inputStr, out int input);

			if(inputBool == false || input < 1 || input > 2)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UICostForOutings();
			}

			if(input == 1)
			{
				UIAllOutings();
			}
			else if(input == 2)
			{
				UIOutingsByType();
			}
		}

		private void UIAllOutings()
		{
			Console.Clear();
			double cost = outingRepo.CostOfAllOutings();
			Console.WriteLine("Cost of All Outings: $" + cost);
			Console.ReadKey();
			InitialPrompt();
		}

		private void UIOutingsByType()
		{
			Console.Clear();
			Console.WriteLine("Enter Event Type To Search For\n1. Fishing\n2. Hunting\n3. Trapping\n4. Hiking");
			string input = Console.ReadLine();
			bool inputBool = int.TryParse(input, out int evnt);

			if (inputBool == false || evnt > 4 || evnt < 0)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				UIOutingsByType();
			}

			Event eventType = Event.Undefined;

			switch (evnt)
			{
				case 1:
					eventType = Event.Fishing;
					break;
				case 2:
					eventType = Event.Hunting;
					break;
				case 3:
					eventType = Event.Trapping;
					break;
				case 4:
					eventType = Event.Hiking;
					break;
				default:
					Console.WriteLine("Wrong!!!!");
					Console.ReadKey();
					UIAddOuting();
					break;
			}

			Console.WriteLine($"Cost of {eventType} events: ${outingRepo.CostOfOutingsByType(eventType)}");
			Console.ReadKey();
			InitialPrompt();
		}

		private void UIExit()
		{

		}
	}
}
