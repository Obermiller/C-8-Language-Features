using Unity;
using VersionEightFeatures.Configuration;
using VersionEightFeatures.Logic.Contracts;

namespace VersionEightFeatures
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var container = UnityBootstrapper.BuildUnityContainer();
			var languageFeaturesLogic = container.Resolve<ILanguageFeaturesLogic>();
			
			languageFeaturesLogic.ExecuteExamples();
		}
	}
}