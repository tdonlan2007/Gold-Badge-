using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
	public class MealItem
	{
		private int _mealNumber;
		private string _mealName;
		private string _description;
		private double _price;

		public int MealNumber
		{
			get
			{
				return _mealNumber;
			}
			set
			{
				_mealNumber = value;
			}
		}
		public string MealName
		{
			get
			{
				return _mealName;
			}
			set
			{
				_mealName = value;
			}
		}
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}
		public double Price
		{
			get
			{
				return _price;
			}
			set
			{
				_price = value;
			}
		}
		public string Ingredients { get; set; }

		private List<string> _ingredients = new List<string>();

		public MealItem(int number, string name, string desc, double price, string ingredients)
		{
			MealNumber = number;
			MealName = name;
			Description = desc;
			Price = price;
			Ingredients = ingredients;
		}

		public void AddIngredientToList(string ingredient)
		{
			_ingredients.Add(ingredient);
		}
	
		public List<string> GetIngredientsList()
		{
			return _ingredients;
		}

		public override string ToString()
		{
			return $"{MealNumber}\t\t{MealName}\t\t{Price}\t\t{Description}\t\t{Ingredients}";
		}
	}
}
