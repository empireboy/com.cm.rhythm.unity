using UnityEngine;

namespace CM.Rhythm
{
	public sealed class RhythmEntityUnity : RhythmEntity<AudioSource>
	{
		public override float Time => Audio.time;
		public override float TotalTime => Audio.clip.length;
		public override bool IsPlaying => Audio.isPlaying;

		public RhythmEntityUnity(AudioSource audio) : base(audio)
		{
			
		}

		protected override void OnPlay()
		{
			Audio.time = 0;

			if (!Audio.isPlaying)
				Audio.Play();
		}

		protected override void OnPlayAt(float time)
		{
			Audio.time = time;

			if (Audio.isPlaying)
				return;

			Audio.Play();
		}

		protected override void OnStop()
		{
			if (!IsPlaying)
				return;

			Audio.Stop();
		}
	}
}