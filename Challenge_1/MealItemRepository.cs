using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
	public class MealItemRepository
	{
		private List<MealItem> _meals = new List<MealItem>()
		{
			new MealItem(1, "Burger", "Tasty Burger", 9.99, "Bun, Onion, Beef, Cheese"),
			new MealItem(2, "Taco", "Spicy Taco", 4.99, "Tortilla, Beef, Lettuce, Cheese"),
			new MealItem(3, "Komodo", "Big Steak", 12.99, "Steak, Seasoning, Fork")
		};

		public List<MealItem> GetList() 
		{
			return _meals;
		}

		public void AddMeal(MealItem meal) 
		{
			_meals.Add(meal);
		}

		public void RemoveMenuItemByName(string name) 
		{
			List<MealItem> removing = _meals.FindAll(x => x.MealName == name);
			foreach(MealItem meal in removing)
			{
				_meals.Remove(meal);
			}
		}

		public void RemoveMenuItemByNumber(int num)	
		{
			List<MealItem> removing = _meals.FindAll(x => x.MealNumber == num);
			foreach (MealItem meal in removing)
			{
				_meals.Remove(meal);
			}
		}

		public int GetCount() 
		{
			return _meals.Count;
		}

		public int AddMealNumber() 
		{
			return _meals.Count + 1;
		}

		public bool VerifyIntResponse(int maxNum, int input) 
		{
			if (input < 0 || input > maxNum)
				return false;
			else
				return true;
		}

		public bool VerifyYesNoResponse(string input)
		{
			if (input == "y" || input == "n" || input == "Y" || input == "N")
				return true;
			else
				return false;
		}
	}
}
