using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Moldor
{
	/// <summary>
	/// Class used to manage (load, unload, reload) plugins dynamically.
	/// </summary>
	public static class AddonManager
	{
		private static readonly List<IMoldorAddon> _addons = new List<IMoldorAddon>();
		private static readonly object LoadLock = new object();

		/// <summary>
		/// List of found assemblies.
		/// </summary>
		public static readonly List<Assembly> Assemblies = new List<Assembly>();
		public static List<IMoldorAddon> GetPlugins() { return _addons; }

		/// <summary>
		/// Initializes the Plugin manager.
		/// </summary>
		public static void Initialize()
		{
			//SetupAppDomainDebugHandlers();
		}

		/// <summary>
		/// Loads plugins from the specified directory.
		/// </summary>
		/// <param name="directory">The directory to check in</param>
		public static void LoadPluginsFromDirectory(DirectoryInfo directory) { LoadPluginsFromDirectory(directory.FullName);}

		/// <summary>
		/// Loads plugins from the specified directory.
		/// </summary>
		/// <param name="directory">The directory to check in</param>
		public static bool LoadPluginsFromDirectory(string directory)
		{
			try
			{
				var dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, directory));
				Console.WriteLine("AddonManager: Loading addons from: {0}", dir.FullName);

				foreach(var dll in dir.GetFiles("*.dll").AsParallel())
				{
					if(!dll.FullName.Contains("Addon"))
						continue;

					var asm = Assembly.LoadFrom(dll.FullName);

					if(asm == null)
						continue;

					IMoldorAddon pl = null;

					foreach(var type in from t in asm.GetTypes().AsParallel() where t.GetInterfaces().Contains(typeof(IMoldorAddon)) select t)
					{
						pl = Activator.CreateInstance(type).Cast<IMoldorAddon>();

						if(pl == null)
							continue;

						pl.Setup();

						lock(LoadLock)
						{
							_addons.Add(pl);
							Assemblies.Add(asm);
						}

						Console.WriteLine("AddonManager: Loaded plugin: {0} {1} by {2} ({3})", pl.Name, asm.GetName().Version.ToString(), pl.Author, pl.Website);
					}
				}

				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("AddonManager: Error while loading one of directories! Detail: {0}", e.Message);
				return false;
			}
		}

		/// <summary>
		/// Unloads all addons.
		/// </summary>
		public static bool UnloadPlugins()
		{
			lock(LoadLock)
			{
				for(var i = 0; i < _addons.Count; ++i)
				{
					var pl = _addons[i];
					pl.Destroy();
					_addons.Remove(pl);
				}

				Assemblies.Clear();
			}

			return true;
		}

		private static void SetupAppDomainDebugHandlers()
		{
			AppDomain.CurrentDomain.DomainUnload += (sender, args) =>
				Console.WriteLine("AddonManager: AppDomain::DomainUnload, hash: {0}", AppDomain.CurrentDomain.GetHashCode());

			AppDomain.CurrentDomain.AssemblyLoad += (sender, ea) =>
				Console.WriteLine("AddonManager: AppDomain::AssemblyLoad, sender is: {0}, loaded assembly: {1}.", sender.GetHashCode(), ea.LoadedAssembly.FullName);

			AppDomain.CurrentDomain.AssemblyResolve += (sender, eargs) =>
			{
				Console.WriteLine("AddonManager: AppDomain::AssemblyResolve, sender: {0}, name: {1}, asm: {2}", sender.GetHashCode(), eargs.Name, eargs.RequestingAssembly.FullName );
				return null;
			};
		}
	}
}
