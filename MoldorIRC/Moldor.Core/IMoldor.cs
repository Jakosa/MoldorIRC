﻿using System;

namespace Moldor
{
	/// <summary>
	/// Another attempt to implement a plugin interface.
	/// </summary>
	public interface IMoldorAddon
	{
		/// <summary>
		/// Creates the addon.
		/// </summary>
		/// <param name="conn">IRC connection.</param>
		/// <param name="channels">Channel list.</param>
		void Setup();
		/// <summary>
		/// Destroys the addon, releasing all resources.
		/// </summary>
		void Destroy();

		/// <summary>
		/// Name of the addon
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Author of the addon.
		/// </summary>
		string Author { get; }
		/// <summary>
		/// Website where the addon is available.
		/// </summary>
		string Website { get; }
	}
}
