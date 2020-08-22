using Unity;

namespace VersionEightFeatures.Configuration
{
	public static class UnityBootstrapper
	{
		public static IUnityContainer BuildUnityContainer()
		{
			var container = new UnityContainer();
			RegisterTypes(container);
			
			return container;
		}

		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<Logic.Contracts.ILanguageFeaturesLogic, Logic.LanguageFeaturesLogic>();
		}
	}
}