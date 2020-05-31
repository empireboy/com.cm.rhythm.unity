using UnityEngine;

namespace CM.Rhythm
{
	public sealed class RhythmEntityUpdaterUnity : RhythmEntityUpdater<AudioSource>
	{
		protected override float Time => UnityEngine.Time.deltaTime;

		public RhythmEntityUpdaterUnity(RhythmEntity<AudioSource> entity) : base(entity)
		{

		}

		protected override void OnUpdate()
		{
			Debug.Log("UPDATE");
		}
	}
}