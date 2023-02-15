using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class ListHelpers
	{
		public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
		public static List<T> WithOnlyValidItems<T>(this IEnumerable<T> list) => list.Where(x => x != null).ToList();

		private static readonly Random Random = new Random();
		public static T RandomElement<T>(this List<T> list) => list[Random.Next(0, list.Count)];
	}
}