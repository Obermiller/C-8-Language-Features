using System.Collections.Generic;
using VersionEightFeatures.Models;

namespace VersionEightFeatures.Logic.Contracts
{
	public interface ILanguageFeaturesLogic
	{
		void ExecuteExamples();
		HashSet<Player> GetCurrentBrownsPlayers(List<Player> players);
		HashSet<Player> GetHallOfFameDefenders(List<Player> players);
	}
}