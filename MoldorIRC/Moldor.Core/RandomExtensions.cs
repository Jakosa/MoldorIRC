using System;
using System.Collections.Generic;
using System.Text;

namespace Moldor
{
	/// <summary>
	/// Some random extension stuff.
	/// </summary>
	public static class RandomExtensions
	{
		/// <summary>
		/// Casts the object to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to cast to.</typeparam>
		/// <param name="ob">Object to cast</param>
		/// <returns>The casted object.</returns>
		public static T Cast<T>(this object ob)
		{
			return (T) ob;
		}

		/// <summary>
		/// Determines whether the specified obj is null.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns>
		/// 	<c>true</c> if the specified obj is null; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNull(this object obj)
		{
			return (obj.IsOfType(typeof(string))) ? (string.IsNullOrEmpty(obj as string)) : (obj == null);
		}

		/// <summary>
		/// Determines whether the specified obj is a type of the specified type.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="type">The type.</param>
		/// <returns>
		/// 	<c>true</c> if the specified obj is a type of the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOfType(this object obj, Type type)
		{
			return (obj.GetType() == type);
		}

		/// <summary>
		/// Determines whether this instance can be casted to the specified type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The obj.</param>
		/// <returns>
		/// 	<c>true</c> if this instance can be casted to the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool CanBeCastedTo<T>(this object obj)
		{
			return (obj is T);
		}

		/// <summary>
		/// Concatenates the string in the specified array and returns the sum string.
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static string Concatenate(this IEnumerable<string> arr)
		{
			var sb = new StringBuilder();

			foreach(var str in arr)
				sb.Append(str);

			return sb.ToString();
		}

		/// <summary>
		/// Concatenates the string in the specified array and returns the sum string.
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="separator">The separator to use between parts.</param>
		/// <returns></returns>
		public static string Concatenate(this IEnumerable<string> arr, string separator)
		{
			var sb = new StringBuilder();

			foreach(var str in arr)
				sb.AppendFormat("{0}{1}", str, separator);

			return sb.ToString();
		}

		/// <summary>
		/// Concatenates the string in the specified array and returns the sum string.
		/// Uses spaces as separators.
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static string ConcatenateWithSpaces(this IEnumerable<string> arr)
		{
			return arr.Concatenate(" ");
		}
	}
}