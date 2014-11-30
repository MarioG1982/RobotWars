using NUnit.Framework;
using System;

namespace RobotWars.Tests
{
	[TestFixture]
	public class RobotTest
	{
		[TestCase("1 2 N", "L", "5 5")]
		[TestCase("1 2 N", "R", "5 5")]
		[TestCase("1 2 N", "M", "5 5")]
		[TestCase("1 2 N", "LRM", "5 5")]
		public void CreatesFromInput(string position, string route, string arenaBoundaries)
		{
			Assert.DoesNotThrow( () => {new Robot(position, route, new Coordinates(arenaBoundaries));});
		}

		[TestCase(null, null, "5 5", typeof(ArgumentException))]
		[TestCase("", "", "5 5", typeof(ArgumentException))]
		[TestCase("1 2 N", "", "5 5", typeof(ArgumentException))]
		[TestCase("asd", "LRM", "5 5", typeof(ArgumentException))]
		[TestCase("1 2 N", "asd", "5 5", typeof(ArgumentException))]
		[TestCase("1 2 N", "LRM", null, typeof(ArgumentException))]
		[TestCase("1 2 N", "LRM", "0 0", typeof(Exception))]
		public void ValidatesInput(string position, string route, string arenaBoundaries, Type expectedEx)
		{
			Assert.Throws( expectedEx,  () => {new Robot(position, route, new Coordinates(arenaBoundaries));});
		}
	}
}
