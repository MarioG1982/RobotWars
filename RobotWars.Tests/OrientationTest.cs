using NUnit.Framework;
using System;

namespace RobotWars.Tests
{
	public class OrientationTest
	{
		[TestCase('N', CardinalPoint.Nord)]
		[TestCase('n', CardinalPoint.Nord)]
		[TestCase('E', CardinalPoint.East)]
		[TestCase('S', CardinalPoint.Sud)]
		[TestCase('W', CardinalPoint.West)]
		public void CreatesFromInput(char input, CardinalPoint expected)
		{
			var sut = new Orientation(input);
			Assert.AreEqual(expected, sut.Current);
		}

		[TestCase(null)]
		[TestCase('a')]
		[TestCase('1')]
		public void ValidatesInput(char input)
		{
			Assert.Throws( typeof(ArgumentException), () => {new Orientation(input);});
		}
	}
}