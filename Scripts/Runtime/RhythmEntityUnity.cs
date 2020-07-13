using UnityEngine;

namespace CM.Rhythm
{
	/// <summary>
	/// Implementation of a Unity audio player.
	/// </summary>
	internal sealed class RhythmEntityUnity : RhythmEntity<AudioSource>
	{
		/// <summary>
		/// The current time in seconds of the audio.
		/// </summary>
		public override float Time => Audio.time;

		/// <summary>
		/// The total time in seconds of the audio.
		/// </summary>
		public override float TotalTime => Audio.clip.length;

		/// <summary>
		/// True if the audio is playing.
		/// </summary>
		public override bool IsPlaying => Audio.isPlaying;

		/// <summary>
		/// Constructor of the RhythmEntityUnity.
		/// </summary>
		/// <param name="audio">The AudioSource component used to play and stop audio.</param>
		public RhythmEntityUnity(AudioSource audio) : base(audio)
		{
			
		}

		protected override void OnPlay()
		{
			Audio.time = 0;

			if (Audio.isPlaying)
				return;

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