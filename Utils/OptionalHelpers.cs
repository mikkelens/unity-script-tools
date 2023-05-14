using System.Diagnostics.CodeAnalysis;
using Tools.Types;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class OptionalHelpers
	{
		public static Optional<T> AsEnabled<T>(this T value) => new Optional<T>(value, true);
		public static Optional<T> AsDisabled<T>(this T value) => new Optional<T>(value, false);
	}
}