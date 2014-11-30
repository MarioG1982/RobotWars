using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars
{
	public class Game
	{
		public Game(string[] input)
		{
			if (input == null) throw new ArgumentException("Game input cannot be null");
			Create(input);
		}

		public Game (string input)
		{
			if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Invalid Game input");
			var parameters = input.Contains("\\n") 
				? input.Replace("\\n",",").Split(',')
				: input.Replace("\n",",").Split(',');
			Create(parameters);
		}

		private void Create(string[] input)
		{
			ArenaBoundaries = new Coordinates(input[0]);
			CreateRobots(input.Skip(1).ToArray());
		}

		public void Play()
		{
			Result = "";
			foreach (var r in Robots)
			{
				r.Move(ArenaBoundaries);
				Result += string.IsNullOrWhiteSpace(Result) ? r.DisplayPosition() : string.Format("\n{0}", r.DisplayPosition());
			}
		}

		private void CreateRobots(string[] input)
		{
			if (input.Length < 2) throw new ArgumentException("Invalid Robots input Parameters");
			Robots = new List<Robot>();
			for (int i = 0; i<input.Length; i+=2) Robots.Add(new Robot(input[i], input[i+1], ArenaBoundaries));			
		}

		private Coordinates ArenaBoundaries { get; set;}
		public List<Robot> Robots { get; private set; }
		public string Result { get; private set;	}
	}
}
