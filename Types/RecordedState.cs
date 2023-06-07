using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Tools.Types
{
	[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class RecordedState<T> where T : Enum, new()
	{
		private readonly Dictionary<T, float> _stateRecord = new Dictionary<T, float>();

		[CanBeNull] public T LastState { get; private set; }
		public float? LastUpdate { get; private set; }

		public RecordedState(T startState, float startTime)
		{
			UpdateState(startState, startTime);
		}
		public void UpdateState([JetBrains.Annotations.NotNull] T state, float currentTime)
		{
			LastState = state;
			LastUpdate = currentTime;
			_stateRecord.Add(state, currentTime);
		}
		public bool StateHasBeenRecorded([JetBrains.Annotations.NotNull] T state)
		{
			return _stateRecord.ContainsKey(state);
		}
		public float? LastTimeOfState(T state)
		{
			return _stateRecord[state];
		}
		public void AddStateToRecord([JetBrains.Annotations.NotNull] T state, float time)
		{
			_stateRecord.Add(state, time);
		}
		public void ClearAllRecordedStates()
		{
			_stateRecord.Clear();
		}
	}
}