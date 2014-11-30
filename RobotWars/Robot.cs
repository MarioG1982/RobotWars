using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars
{
	public class Robot
	{
		private readonly Coordinates arenaBoundaries;
		public Robot(string position, string route, Coordinates arenaBoundaries)
		{
			this.arenaBoundaries = arenaBoundaries;
			Position = new Coordinates(position);
			ValidatePosition();
			Orientation = new Orientation(position.Last());
			ValidateRoute(route);
			Route = route;
		}

		private void ValidatePosition()
		{
			if (Position.X <= arenaBoundaries.X && Position.Y <= arenaBoundaries.Y) return; 
			throw new Exception("Robot is in illegal position");
		}

		private void ValidateRoute(string route)
		{
			if (string.IsNullOrWhiteSpace(route)) throw new ArgumentException("Route cannot be null or empty or white space");
			foreach( var r in route.ToCharArray())
				if (!"LlRlMm".ToCharArray().Any(x => x == r)) throw new ArgumentException("Invalid route input format");
		}

		public Coordinates Position { get; set; }
		public Orientation Orientation { get; private set; }
		public string Route { get; private set; }

		public void Move(Coordinates boundaries)
		{
			foreach (var command in Route.ToCharArray()) 
			{
				ExecuteStep(command);			
				ValidatePosition();
			}
		}

		private void ExecuteStep(char command)
		{
			switch(command.ToString().ToUpperInvariant())
			{
				case "M":
					GoForward();
					break;
				case "L":
					RotateLeft();
					break;
				case "R":
					RotateRight();
					break;
			}
		}

		public void GoForward()
		{
			switch(Orientation.Current)
			{
				case CardinalPoint.Nord:
				Position.Y++;
					break;
				case CardinalPoint.East:
					Position.X++;
					break;
				case CardinalPoint.Sud:
					Position.Y--;
					break;
				case CardinalPoint.West:
					Position.X--;
					break;
			}
		}

		public void RotateLeft()
		{
			switch(Orientation.Current)
			{
				case CardinalPoint.Nord:
					Orientation.Current = CardinalPoint.West;
					break;
				case CardinalPoint.East:
					Orientation.Current = CardinalPoint.Nord;
					break;
				case CardinalPoint.Sud:
					Orientation.Current = CardinalPoint.East;
					break;
				case CardinalPoint.West:
					Orientation.Current = CardinalPoint.Sud;
					break;
			}
		}

		public void RotateRight()
		{
			switch(Orientation.Current)
			{
				case CardinalPoint.Nord:
					Orientation.Current = CardinalPoint.East;
					break;
				case CardinalPoint.East:
					Orientation.Current = CardinalPoint.Sud;
					break;
				case CardinalPoint.Sud:
					Orientation.Current = CardinalPoint.West;
					break;
				case CardinalPoint.West:
					Orientation.Current = CardinalPoint.Nord;
					break;
			}
		}

		public string DisplayPosition()
		{
			return string.Format("{0} {1} {2}", Position.X, Position.Y, Orientation.Current.ToString()[0]);
		}
	}
}