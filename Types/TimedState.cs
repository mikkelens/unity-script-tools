using System;
using UnityEngine;

namespace Scripts.Tools.Types
{
	[Serializable]
	public struct TimedState
	{
		[SerializeField] private bool state;
		[SerializeField] private float latestTimeTrue;
		[SerializeField] private float latestTimeFalse;
		[SerializeField] private float startTimeTrue;
		[SerializeField] private float startTimeFalse;

		public float LatestTimeTrue => latestTimeTrue;
		public float LatestTimeFalse => latestTimeFalse;
		public float StartTimeTrue => startTimeTrue;
		public float StartTimeFalse => startTimeFalse;
		public bool State // never really accessed?
		{
			get => state;
			set
			{
				if (value) // true
				{
					if (!state) startTimeTrue = Time.time; // start of true
					latestTimeTrue = Time.time;
				}
				else // false
				{
					if (state) startTimeFalse = Time.time; // start of false
					latestTimeFalse = Time.time;
				}
				state = value;
			}
		}

		// IMPLICIT GET VALUE FROM STRUCT
		public static implicit operator bool(TimedState timedStateSource) => timedStateSource.State;

		// IMPLICIT ASSIGN STRUCT FROM STATE
		// public static implicit operator TimedState(bool stateSource) => new TimedState(stateSource);

		public TimedState(bool startState)
		{
			state = startState;
			if (startState)
			{
				startTimeTrue = latestTimeTrue = Time.time;
				startTimeFalse = latestTimeFalse = -99999f;
			}
			else
			{
				startTimeFalse = latestTimeFalse = Time.time;
				startTimeTrue = latestTimeTrue = -99999f;
			}
		}
	}
}