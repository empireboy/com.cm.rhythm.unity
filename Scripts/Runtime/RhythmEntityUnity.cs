using UnityEngine;

namespace CM.Rhythm
{
	/// <summary>
	/// Implementation of a Unity audio player.
	/// </summary>
	internal sealed class RhythmEntityUnity : RhythmEntity
	{
		/// <summary>
		/// The current time in seconds of the audio.
		/// </summary>
		public override float Time => _audioSource.time;

		/// <summary>
		/// The total time in seconds of the audio.
		/// </summary>
		public override float TotalTime => _audioSource.clip.length;

		/// <summary>
		/// True if the audio is playing.
		/// </summary>
		public override bool IsPlaying => _audioSource.isPlaying;

		private AudioSource _audioSource = null;

		/// <summary>
		/// Constructor of the RhythmEntityUnity.
		/// </summary>
		/// <param name="audioSource">The AudioSource component used to play and stop audio.</param>
		public RhythmEntityUnity(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}

		protected override void OnPlay()
		{
			_audioSource.time = 0;

			if (_audioSource.isPlaying)
				return;

			_audioSource.Play();
		}

		protected override void OnPlayAt(float time)
		{
			_audioSource.time = time;

			if (_audioSource.isPlaying)
				return;

			_audioSource.Play();
		}

		protected override void OnStop()
		{
			if (!IsPlaying)
				return;

			_audioSource.Stop();
		}
	}
}