using System;
using System.Collections.Generic;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
	[TestClass]
	public class ClaimRepositoryTestClass
	{
		ClaimRepository claimRepo = new ClaimRepository();

		[TestMethod]
		public void ClaimRepository_GetList_ShouldBeSameCountAsDefaultList()
		{
			//-- arrange
			List<Claim> tempList = claimRepo.GetList();

			//-- act
			int actual = tempList.Count;
			int expected = 3;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ClaimRepository_AddClaim_ShouldBeSameCountAfterAddingItem()
		{
			//-- arrange
			List<Claim> tempList = new List<Claim>();
			Claim newClaim = new Claim(1, 400, "Crash", DateTime.Parse("4/25/2018"), DateTime.Parse("4/27/18"), ClaimType.Car);

			//-- act
			claimRepo.AddClaim(newClaim);
			tempList = claimRepo.GetList();
			int actual = tempList.Count;
			int expected = 4;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ClaimRepository_GetFirstItem_ClaimIDShouldBeSame()
		{
			//-- arrange
			List<Claim> tempList = new List<Claim>();

			//-- act
			Claim actualClaim = claimRepo.GetFirstItem();
			int actual = actualClaim.ClaimID;
			int expected = 1;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ClaimRepository_RemoveFirstItem_AfterRemovingFirstItemIDShouldBe2ForNextItem()
		{
			//-- arrange
			List<Claim> tempList = new List<Claim>();
			claimRepo.RemoveFirstItem();
			tempList = claimRepo.GetList();

			//-- act
			int actual = tempList[0].ClaimID;
			int expected = 2;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ClaimRepository_VerifyIntResponse_ShouldBeTrueBasedOnInputs()
		{
			//-- arrange
			int maxNum = 3;
			int input = 2;

			//-- act
			bool actual = claimRepo.VerifyIntResponse(maxNum, input);
			bool expected = true;

			//-- assert
			Assert.AreEqual(expected, actual);
		}
	}
}
