using System;
using System.Linq;

namespace RobotWars
{
	public class Orientation
	{
		private Orientation(){}
		public Orientation(char input)
		{
			Validate(input);
			SetCurrent(input);
		}
	
		public CardinalPoint Current { get; set; }

		private void Validate(char input)
		{
			if (!"NnEeSsWw".ToCharArray().Any(x => x == input)) throw new ArgumentException("Invalid cardinal point input format");
		}

		private void SetCurrent(char input)
		{
			switch(input.ToString().ToUpperInvariant())
			{
				case "N":
					Current = CardinalPoint.Nord;
					break;
				case "E":
					Current = CardinalPoint.East;
					break;
				case "S":
					Current = CardinalPoint.Sud;
					break;
				case "W":
					Current = CardinalPoint.West;
					break;
			}
		}
	}
}
