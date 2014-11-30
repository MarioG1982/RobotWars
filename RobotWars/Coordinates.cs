using System;

namespace RobotWars
{
	public class Coordinates
	{
		public Coordinates(){}

		public Coordinates(string input)
		{
			if (string.IsNullOrWhiteSpace(input))throw new ArgumentException("input cannot be null or empty or white space");
			var parameters = input.Split(' ');
			if(parameters.Length < 2) throw new ArgumentException("Invalid input: two coordinates needed");
			uint x;
			uint y;
			if (!(uint.TryParse(parameters[0], out x) && uint.TryParse(parameters[1], out y)))		
				throw new ArgumentException("Invalid coordinate format");
			X = x; 
			Y = y;
		}

		public uint X {get;set;}
		public uint Y {get;set;}
	}
}