using System;
using System.Collections.Generic;
using System.Linq;
using UnconstrainedMelody;
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

			List<Player> BuildPlayerModels() //This data would normally come from a stored procedure, but I'm going to hardcode it for now.
			{
				var brownsId = Guid.NewGuid();

				return new List<Player>
				{
					new Player
					{
						Id = Guid.NewGuid(),
						IsActive = true,
						IsInHallOfFame = false,
						Name = "Baker Mayfield",
						Positions = Position.Quarterback,
						PrimaryNumber = 6,
						Teams = new List<Team>
						{
							new Team
							{
								Id = brownsId,
								City = "Cleveland",
								Name = "Browns"
							}
						}
					},
					new Player
					{
						Id = Guid.NewGuid(),
						IsActive = false,
						IsInHallOfFame = true,
						Name = "Deion Sanders",
						Positions = Position.Cornerback | Position.WideReceiver,
						PrimaryNumber = 21,
						Teams = new List<Team>
						{
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Atlanta",
								Name = "Falcons"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "San Francisco",
								Name = "49ers"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Dallas",
								Name = "Cowboys"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Washington",
								Name = "Redskins"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Baltimore",
								Name = "Ravens"
							}
						}
					},
					new Player
					{
						Id = Guid.NewGuid(),
						IsActive = false,
						IsInHallOfFame = false,
						Name = "Peyton Hillis",
						Positions = Position.Halfback & Position.Fullback,
						PrimaryNumber = 40,
						Teams = new List<Team>
						{
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Denver",
								Name = "Broncos"
							},
							new Team
							{
								Id = brownsId,
								City = "Cleveland",
								Name = "Browns"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Kansas City",
								Name = "Chiefs"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "Tampa Bay",
								Name = "Buccaneers"
							},
							new Team
							{
								Id = Guid.NewGuid(),
								City = "New York",
								Name = "Giants"
							}
						}
					}
				};
			}
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
				=> (player.IsInHallOfFame, player.Positions.HasAny(Position.End | Position.Nose | Position.Linebacker | Position.Cornerback | Position.Safety)) switch
				{
					(true, true) => true,
					(_, _) => false
				};
		}
	}
}