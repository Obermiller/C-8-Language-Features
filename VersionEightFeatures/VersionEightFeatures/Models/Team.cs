using System;

namespace VersionEightFeatures.Models
{
	public class Team
	{
		public Guid Id { get; set; } //Ideally this would come from a DB. I'm adding out of principle.
		public string City { get; set; }
		public string Name { get; set; }
		public string DisplayName => City + " " + Name;
	}
}