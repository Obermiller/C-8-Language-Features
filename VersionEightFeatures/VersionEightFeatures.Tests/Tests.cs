using NUnit.Framework;

namespace VersionEightFeatures.Tests
{
	[TestFixture]
	public class Tests
	{
		[Test, Explicit]
		public void ProgramMainIntegration()
		{
			Program.Main(new string[0]);
		}
	}
}