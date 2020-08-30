using System;
using System.Collections.Generic;
using VersionEightFeatures.Enums;

namespace VersionEightFeatures.Models
{
	public class Player
	{
		public Guid Id { get; set; } //Ideally this would come from a DB. I'm adding out of principle.
		public bool IsActive { get; set; }
		public bool IsInHallOfFame { get; set; }
		public string Name { get; set; }
		public Position Positions { get; set; }
		public int PrimaryNumber { get; set; }
		public List<Team> Teams { get; set; } = new List<Team>();
	}
}