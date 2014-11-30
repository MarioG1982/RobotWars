using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
	[TestFixture]
	public class CoordinatesTest
	{
		[TestCase("5 5", 5, 5)]
		[TestCase("5 6", 5, 6)]
		public void CreatesFromInput(string input, int expectedX, int expectedY)
		{
			var sut = new Coordinates(input);
			Assert.AreEqual(expectedX, sut.X);
			Assert.AreEqual(expectedY, sut.Y);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("asd")]
		[TestCase("5")]
		[TestCase("5 @")]
		public void ValidatesInput(string input)
		{
			Assert.Throws( typeof(ArgumentException), () => {new Coordinates(input);});
		}
	}
}