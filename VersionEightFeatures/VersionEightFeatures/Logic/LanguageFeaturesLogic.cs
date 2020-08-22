using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Interception.Utilities;
using VersionEightFeatures.Enums;
using VersionEightFeatures.Logic.Contracts;
using VersionEightFeatures.Models;

namespace VersionEightFeatures.Logic
{
	public class LanguageFeaturesLogic : ILanguageFeaturesLogic
	{
		public void ExecuteExamples()
		{
			var players = BuildPlayerModels();

			var currentBrownsPlayers = GetCurrentBrownsPlayers(players);
			Console.WriteLine("Players currently with the Browns: " + currentBrownsPlayers.JoinStrings(", ", player => player.Name));
			
			var hallOfFameDefenders = GetHallOfFameDefenders(players);
			Console.WriteLine("Defenders in the hall of fame: " + hallOfFameDefenders.JoinStrings(", ", player => player.Name));
			
			List<Player> BuildPlayerModels() //This would normally come from a database stored procedure, but I'm going to hardcode it for now.
				=> new List<Player>
				{
					new Player
					{
						Id = 1,
						IsActive = true,
						IsInHallOfFame = false,
						Name = "Baker Mayfield",
						Positions = Position.Quarterback,
						PrimaryNumber = 6,
						Teams = new List<Team>
						{
							new Team
							{
								Id = 1,
								City = "Cleveland",
								Name = "Browns"
							}
						}
					},
					new Player
					{
						Id = 2,
						IsActive = false,
						IsInHallOfFame = true,
						Name = "Deion Sanders",
						Positions = Position.Cornerback | Position.WideReceiver,
						PrimaryNumber = 21,
						Teams = new List<Team>
						{
							new Team
							{
								Id = 2,
								City = "Atlanta",
								Name = "Falcons"
							},
							new Team
							{
								Id = 3,
								City = "San Francisco",
								Name = "49ers"
							},
							new Team
							{
								Id = 4,
								City = "Dallas",
								Name = "Cowboys"
							},
							new Team
							{
								Id = 5,
								City = "Washington",
								Name = "Redskins"
							},
							new Team
							{
								Id = 6,
								City = "Baltimore",
								Name = "Ravens"
							}
						}
					},
					new Player
					{
						Id = 3,
						IsActive = false,
						IsInHallOfFame = false,
						Name = "Peyton Hillis",
						Positions = Position.Halfback & Position.Fullback,
						PrimaryNumber = 40,
						Teams = new List<Team>
						{
							new Team
							{
								Id = 7,
								City = "Denver",
								Name = "Broncos"
							},
							new Team
							{
								Id = 1,
								City = "Cleveland",
								Name = "Browns"
							},
							new Team
							{
								Id = 8,
								City = "Kansas City",
								Name = "Chiefs"
							},
							new Team
							{
								Id = 9,
								City = "Tampa Bay",
								Name = "Buccaneers"
							},
							new Team
							{
								Id = 10,
								City = "New York",
								Name = "Giants"
							}
						}
					}
				};
		}

		public HashSet<Player> GetCurrentBrownsPlayers(List<Player> players) //Switch expression utilizing pattern matching
		{
			return players.Where(player => IsActiveBrownsPlayer(player.IsActive, player.Teams.LastOrDefault())).ToHashSet(); //The last listed team is the most recent team in my cases.

			static bool IsActiveBrownsPlayer(bool isActive, Team team) //Static local function
				=> team switch
				{
					{ DisplayName: "Cleveland Browns" } when isActive => true,
					_ => false
				};
		}

		public HashSet<Player> GetHallOfFameDefenders(List<Player> players) //Switch expression utilizing touples
		{
			return players.Where(IsHallOfFameDefender).ToHashSet();

			static bool IsHallOfFameDefender(Player player) //Static local function
				=> (player.IsInHallOfFame, player.Positions.HasFlag(Position.End & Position.Nose & Position.Linebacker & Position.Cornerback & Position.Safety)) switch
				{
					(true, true) => true,
					(_, _) => false
				};
		}
	}
}