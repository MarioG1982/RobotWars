using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
	[TestFixture]
	public class GameTest
	{
		private readonly string input = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";

		[Test]
		public void CreatesRobots()
		{
			var sut = new Game(input);
			Assert.AreEqual(2, sut.Robots.Count);
			Assert.AreEqual(CardinalPoint.Nord, sut.Robots[0].Orientation.Current);
			Assert.AreEqual(CardinalPoint.East, sut.Robots[1].Orientation.Current);
			Assert.AreEqual("LMLMLMLMM", sut.Robots[0].Route);
			Assert.AreEqual("MMRMMRMRRM", sut.Robots[1].Route);
		}

		[Test]
		public void CreatesRobotsFromArray()
		{
			var sut = new Game(input.Replace("\n",",").Split(','));
			Assert.AreEqual(2, sut.Robots.Count);
			Assert.AreEqual(CardinalPoint.Nord, sut.Robots[0].Orientation.Current);
			Assert.AreEqual(CardinalPoint.East, sut.Robots[1].Orientation.Current);
			Assert.AreEqual("LMLMLMLMM", sut.Robots[0].Route);
			Assert.AreEqual("MMRMMRMRRM", sut.Robots[1].Route);
		}

		[Test]
		public void DoWar()
		{
			var expectedOutput = "1 3 N\n5 1 E";
			var sut = new Game(input);
			sut.Play();
			Assert.AreEqual(expectedOutput, sut.Result);
		}
	}
}
