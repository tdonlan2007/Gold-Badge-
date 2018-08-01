using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
	public class ProgramUI
	{
		MealItemRepository mealRepo = new MealItemRepository();
		private List<MealItem> _tempList = new List<MealItem>();

		public void Run()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			InitialPrompt();
		}

		public void InitialPrompt()
		{
			Console.Clear();
			Console.WriteLine("What would you like to do:\n1. See Menu\n2. Add Item\n3. Remove Item\n4. Exit");
			string respStr = Console.ReadLine();
			bool respBool = int.TryParse(respStr, out int input);
			
			if(mealRepo.VerifyIntResponse(4, input) == false || respBool == false)
			{
				Console.Clear();
				Console.WriteLine("INVALID RESPONSE");
				Console.ReadKey();
				InitialPrompt();
			}

			switch(input)
			{
				case 1:
					UISeeMenu();
					break;
				case 2:
					UIAddItem();
					break;
				case 3:
					UIRemoveItem();
					break;
				case 4:
					Exit();
					break;
			}
		}

		public void UISeeMenu()
		{
			Console.Clear();

			_tempList = mealRepo.GetList();
			foreach(MealItem meal in _tempList)
				Console.WriteLine(meal);

			Console.ReadKey();
			InitialPrompt();
		}

		public void UIAddItem()
		{
			Console.Clear();

			Console.Write("Enter Name: ");
			string name = Console.ReadLine();

			Console.Write("Enter Brief Description: ");
			string desc = Console.ReadLine();

			Console.Write("Enter Price: ");
			string priceStr = Console.ReadLine();
			bool priceBool = double.TryParse(priceStr, out double price);
			if(priceBool == false)
			{
				Console.Clear();
				Console.WriteLine(priceStr + " is not a valid price");
				Console.ReadKey();
				UIAddItem();
			}

			Console.Write("Enter ingredients: ");
			string ingredients = Console.ReadLine();

			MealItem newMeal = new MealItem(mealRepo.AddMealNumber(), name, desc, price, ingredients);
			mealRepo.AddMeal(newMeal);
			_tempList = mealRepo.GetList();

			Console.Clear();
			Console.Write("Meal Added\nAdd Another? (Y/N) ");
			string input = Console.ReadLine();

			if (mealRepo.VerifyYesNoResponse(input) == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response, Returning to Home Screen");
				Console.ReadKey();
				InitialPrompt();
			}
			else if (input == "y")
				UIAddItem();
			else
				InitialPrompt();
		}

		public void UIRemoveItem()
		{
			Console.Clear();
			Console.WriteLine("1. Remove By Name\n2. Remove By Number");
			string inputStr = Console.ReadLine();
			bool verifyInput = int.TryParse(inputStr, out int input);
			if (mealRepo.VerifyIntResponse(2, input) == false || verifyInput == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response");
				Console.ReadKey();
				UIRemoveItem();
			}

			if (input == 1)
				UIRemoveByName();
			else if (input == 2)
				UIRemoveByNumber();
			else
			{
				Console.WriteLine("Something went HELLA wrong here");
				Console.ReadKey();
				UIRemoveItem();
			}
		}

		public void UIRemoveByName()
		{
			Console.Clear();

			foreach (MealItem meal in mealRepo.GetList())
				Console.WriteLine(meal);
			Console.Write("Enter Name of Item To Remove (NOTE: CASE SENSITIVE): ");
			string itemName = Console.ReadLine();

			mealRepo.RemoveMenuItemByName(itemName);
			_tempList = mealRepo.GetList();
			Console.Clear();
			Console.Write("Meal Removed\nRemove Another? (Y/N) ");
			string input = Console.ReadLine();

			if (mealRepo.VerifyYesNoResponse(input) == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response, Returning to Home Screen");
				Console.ReadKey();
				InitialPrompt();
			}
			else if (input == "y")
				UIRemoveByName();
			else
				InitialPrompt();
		}

		public void UIRemoveByNumber()
		{
			Console.Clear();
			foreach (MealItem meal in mealRepo.GetList())
				Console.WriteLine(meal);
			Console.Write("Enter Meal Number To Remove: ");
			string inputStr = Console.ReadLine();

			bool inputBool = int.TryParse(inputStr, out int input);
			if(mealRepo.VerifyIntResponse(mealRepo.GetCount(), input) == false || inputBool == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response");
				Console.ReadKey();
				UIRemoveByNumber();
			}

			mealRepo.RemoveMenuItemByNumber(input);
			_tempList = mealRepo.GetList();

			Console.Write("Meal Removed\nRemove Another? (Y/N) ");
			string repeat = Console.ReadLine();

			if (mealRepo.VerifyYesNoResponse(repeat) == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Response, Returning to Home Screen");
				Console.ReadKey();
				InitialPrompt();
			}
			else if (repeat == "y")
				UIRemoveByNumber();
			else
				InitialPrompt();
		}

		public void Exit()
		{

		}
	}
}
