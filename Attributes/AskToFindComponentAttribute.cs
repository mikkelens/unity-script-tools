using System;
using UnityEngine;

namespace Tools.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class AskToFindComponentAttribute : PropertyAttribute { }
}