using Unity;
using Unity.Lifetime;

namespace Lemonway.Services.Controllers
{
    /// <summary>
    /// This class is used to inject dependencies
    /// </summary>
    public class DependencyInjector
    {
        /// <summary>
        /// Instanciation of UnityContainer
        /// </summary>
        private static readonly UnityContainer UnityContainer = new UnityContainer();

        /// <summary>
        /// The register method
        /// </summary>
        /// <typeparam name="I"> Interface</typeparam>
        /// <typeparam name="T">Represents a class</typeparam>
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Used to retrieve an object
        /// </summary>
        /// <typeparam name="T"> Generic object</typeparam>
        /// <returns>an object</returns>
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}