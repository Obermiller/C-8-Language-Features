using Unity;
using VersionEightFeatures.Configuration;
using VersionEightFeatures.Logic.Contracts;

namespace VersionEightFeatures
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var container = UnityBootstrapper.BuildUnityContainer();
			var languageFeaturesLogic = container.Resolve<ILanguageFeaturesLogic>();
			
			languageFeaturesLogic.ExecuteExamples();
		}
	}
}