using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class GradientUtils
	{
		public static Gradient Lerp(Gradient a, Gradient b, float t)
		{
			return Lerp(a, b, t, false, false);
		}

		public static Gradient LerpNoAlpha(Gradient a, Gradient b, float t)
		{
			return Lerp(a, b, t, true, false);
		}

		public static Gradient LerpNoColor(Gradient a, Gradient b, float t)
		{
			return Lerp(a, b, t, false, true);
		}

		private static Gradient Lerp(Gradient a, Gradient b, float t, bool noAlpha, bool noColor)
		{
			//list of all the unique key times
			List<float> keysTimes = new List<float>();

			if (!noColor)
			{
				for (int i = 0; i < a.colorKeys.Length; i++)
				{
					float k = a.colorKeys[i].time;
					if (!keysTimes.Contains(k))
						keysTimes.Add(k);
				}

				for (int i = 0; i < b.colorKeys.Length; i++)
				{
					float k = b.colorKeys[i].time;
					if (!keysTimes.Contains(k))
						keysTimes.Add(k);
				}
			}

			if (!noAlpha)
			{
				for (int i = 0; i < a.alphaKeys.Length; i++)
				{
					float k = a.alphaKeys[i].time;
					if (!keysTimes.Contains(k))
						keysTimes.Add(k);
				}

				for (int i = 0; i < b.alphaKeys.Length; i++)
				{
					float k = b.alphaKeys[i].time;
					if (!keysTimes.Contains(k))
						keysTimes.Add(k);
				}
			}

			GradientColorKey[] clrs = new GradientColorKey[keysTimes.Count];
			GradientAlphaKey[] alphas = new GradientAlphaKey[keysTimes.Count];

			//Pick colors of both gradients at key times and lerp them
			for (int i = 0; i < keysTimes.Count; i++)
			{
				float key = keysTimes[i];
				Color clr = Color.Lerp(a.Evaluate(key), b.Evaluate(key), t);
				clrs[i] = new GradientColorKey(clr, key);
				alphas[i] = new GradientAlphaKey(clr.a, key);
			}

			Gradient g = new Gradient();
			g.SetKeys(clrs, alphas);

			return g;
		}
	}
}