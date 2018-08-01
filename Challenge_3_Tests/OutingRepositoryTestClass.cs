using System;
using System.Collections.Generic;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingRepositoryTestClass
    {
		OutingRepository outingRepo = new OutingRepository();

        [TestMethod]
        public void OutingRepository_GetList_CountShouldBeSame()
        {
			//-- arrange
			List<Outing> outings = new List<Outing>();

			//-- act
			outings = outingRepo.GetList();
			int actual = outings.Count;
			int expected = 0;

			//-- assert
			Assert.AreEqual(expected, actual);
        }

		[TestMethod]
		public void OutingRepository_UpdateList_CountShouldBeSameAfterAddingItem()
		{
			//-- arrange
			List<Outing> outings = new List<Outing>();
			Outing outing = new Outing(Event.AmusementPark, 40, DateTime.Parse("7/21/18"), 50, 5000);

			//-- act
			outingRepo.UpdateList(outing);
			outings = outingRepo.GetList();
			int actual = outings.Count;
			int expected = 1;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OutingRepository_CostOfAllOutings_SumShouldBeSame()
		{
			//-- arrange
			List<Outing> outings = new List<Outing>();
			Outing outing = new Outing(Event.AmusementPark, 40, DateTime.Parse("7/21/18"), 50, 5000);

			//-- act
			outingRepo.UpdateList(outing);
			outings = outingRepo.GetList();
			double actual = outingRepo.CostOfAllOutings();
			double expected = 5000;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void OutingRepository_CostOfOutingsByType_DoubleShouldBeSame()
		{
			//-- arrange
			List<Outing> outings = new List<Outing>();
			Outing outing = new Outing(Event.AmusementPark, 40, DateTime.Parse("7/21/18"), 50, 5000);

			//-- act
			outingRepo.UpdateList(outing);
			double actual = outingRepo.CostOfOutingsByType(Event.AmusementPark);
			double expected = 5000;

			//-- assert
			Assert.AreEqual(expected, actual);
		}
    }
}
