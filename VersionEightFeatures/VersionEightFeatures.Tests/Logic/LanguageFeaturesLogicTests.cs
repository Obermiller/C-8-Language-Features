using System.Collections.Generic;
using NUnit.Framework;
using VersionEightFeatures.Enums;
using VersionEightFeatures.Logic;
using VersionEightFeatures.Logic.Contracts;
using VersionEightFeatures.Models;

namespace VersionEightFeatures.Tests.Logic
{
	[TestFixture]
	public class LanguageFeaturesLogicTests
	{
		private ILanguageFeaturesLogic _languageFeaturesLogic;

		[SetUp]
		public void Setup()
		{
			_languageFeaturesLogic = new LanguageFeaturesLogic();
		}

		#region GetCurrentBrownsPlayersTests

		[Test]
		[TestCase("Cleveland", "Browns", true)]
		public void IsCurrentBrownsPlayerTest(string city, string teamName, bool isActive)
		{
			//Arrange
			var player = CreatePlayerForBrownsCheck(city, teamName, isActive);
			
			//Act
			var currentBrownsPlayer = _languageFeaturesLogic.GetCurrentBrownsPlayers(player);
			
			//Assert
			Assert.IsNotEmpty(currentBrownsPlayer);
			Assert.AreEqual(currentBrownsPlayer.Count, 1);
		}

		[Test]
		[TestCase("Cleveland", "Browns", false)]
		[TestCase("Cleveland", "Ravens", true)]
		[TestCase("Cleveland", "Ravens", false)]
		[TestCase("Baltimore", "Browns", true)]
		[TestCase("Baltimore", "Browns", false)]
		[TestCase("Detroit", "Lions", true)]
		[TestCase("Detroit", "Lions", false)]
		public void IsNotCurrentBrownsPlayerTest(string city, string teamName, bool isActive)
		{
			//Arrange
			var player = CreatePlayerForBrownsCheck(city, teamName, isActive);
			
			//Act
			var currentBrownsPlayer = _languageFeaturesLogic.GetCurrentBrownsPlayers(player);
			
			//Assert
			Assert.IsEmpty(currentBrownsPlayer);
		}

		private static List<Player> CreatePlayerForBrownsCheck(string city, string teamName, bool isActive)
			=> new List<Player>
			{
				new Player
				{
					IsActive = isActive,
					Teams = new List<Team>
					{
						new Team
						{
							City = city,
							Name = teamName
						}
					}
				}
			};

		#endregion

		#region GetHallOfFameDefenders

		[Test]
		[TestCase(Position.End, true)]
		[TestCase(Position.Nose, true)]
		[TestCase(Position.Linebacker, true)]
		[TestCase(Position.Cornerback, true)]
		[TestCase(Position.Safety, true)]
		public void IsHallOfFameDefender(Position positions, bool isInHallOfFame)
		{
			//Arrange
			var player = CreatePlayerForHallOfFameDefenderCheck(positions, isInHallOfFame);
			
			//Act
			var hallOfFameDefender = _languageFeaturesLogic.GetHallOfFameDefenders(player);
			
			//Assert
			Assert.IsNotEmpty(hallOfFameDefender);
			Assert.AreEqual(hallOfFameDefender.Count, 1);
		}
		
		[Test]
		[TestCase(Position.End, false)]
		[TestCase(Position.Nose, false)]
		[TestCase(Position.Linebacker, false)]
		[TestCase(Position.Cornerback, false)]
		[TestCase(Position.Safety, false)]
		[TestCase(Position.Quarterback, true)]
		[TestCase(Position.Quarterback, false)]
		[TestCase(Position.Halfback, true)]
		[TestCase(Position.Halfback, false)]
		[TestCase(Position.Fullback, true)]
		[TestCase(Position.Fullback, false)]
		[TestCase(Position.WideReceiver, true)]
		[TestCase(Position.WideReceiver, false)]
		[TestCase(Position.TightEnd, true)]
		[TestCase(Position.TightEnd, false)]
		[TestCase(Position.Center, true)]
		[TestCase(Position.Center, false)]
		[TestCase(Position.Guard, true)]
		[TestCase(Position.Guard, false)]
		[TestCase(Position.Tackle, true)]
		[TestCase(Position.Tackle, false)]
		public void IsNotHallOfFameDefender(Position positions, bool isInHallOfFame)
		{
			//Arrange
			var player = CreatePlayerForHallOfFameDefenderCheck(positions, isInHallOfFame);
			
			//Act
			var hallOfFameDefender = _languageFeaturesLogic.GetHallOfFameDefenders(player);
			
			//Assert
			Assert.IsEmpty(hallOfFameDefender);
		}
		
		private static List<Player> CreatePlayerForHallOfFameDefenderCheck(Position positions, bool isInHallOfFame)
			=> new List<Player>
			{
				new Player
				{
					IsInHallOfFame = isInHallOfFame,
					Positions = positions
				}
			};
		
		#endregion
	}
}