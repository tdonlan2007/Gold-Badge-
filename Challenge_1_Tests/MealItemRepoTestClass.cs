using System;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Challenge_1_Tests
{
    [TestClass]
    public class MealItemRepoTestClass
    {
		private MealItemRepository mealRepo = new MealItemRepository();

        [TestMethod]
        public void MealItemRepository_GetList_CountShouldBeSame()
        {
			//-- arrange
			List<MealItem> mealList = new List<MealItem>();
			mealList = mealRepo.GetList();

			//-- act
			int actual = mealList.Count;
			int expected = 3;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MealItemRepository_CreateMenuItem_ListShouldBeSame()
		{
			//-- arrange
			List<MealItem> actualList = new List<MealItem>();
			MealItem komodo2 = new MealItem(4, "Salad2", "Big House", 12.99, "Ingredients");
			mealRepo.AddMeal(komodo2);

			//-- act
			actualList = mealRepo.GetList();
			int actual = actualList.Count;
			int expected = 4;

			//-- assert
			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void MealItemRepository_AddMeal_CountShouldBeSame()
		{
			//-- arrange
			MealItem newMeal = new MealItem(4, "Apple", "an Apple", 0.99, "Ingredients");
			mealRepo.AddMeal(newMeal);

			//-- act
			int actual = mealRepo.GetCount();
			int expected = 4;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		
		[TestMethod]
		public void MealItemRepository_RemoveListItemByNumber_ShouldBeSameCount()
		{
			//-- arrange
			int num = 1;
			mealRepo.RemoveMenuItemByNumber(num);

			//-- act
			int actual = mealRepo.GetCount();
			int expected = 2;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MealItemRepository_GetCount_ShouldBeSameCount()
		{
			//-- arrange
			int actual;

			//-- act
			actual = mealRepo.GetCount();
			int expected = 3;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MealItemRepository_AddMealNumber_ShouldAddNumberBasedOnCount()
		{
			//-- arrange
			int actual;
			int expected = 4;

			//-- act
			actual = mealRepo.AddMealNumber();

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MealItemRepository_VerifyIntResponse_BoolsShouldBeEqual()
		{ 
			//-- arrange
			int OptionCount = 4;
			int input1 = 3;
			//int input2 = 5;

			//-- act
			bool actual = mealRepo.VerifyIntResponse(OptionCount, input1);
			bool expected = true;

			//-- assert
			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void MealItemRepository_VerifyYesNoResponse_BoolShouldBeEqual()
		{
			//-- arrange
			string input = "Y";

			//-- act
			bool actual = mealRepo.VerifyYesNoResponse(input);
			bool expected = true;

			//-- assert
			Assert.AreEqual(expected, actual);
		}
	}
}
