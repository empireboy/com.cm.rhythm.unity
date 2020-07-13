using UnityEngine;

namespace CM.Rhythm
{
	/// <summary>
	/// A proxy for the RhythmEntity class.
	/// This Unity proxy can be used for any type of rhythm project.
	/// </summary>
	public sealed class RhythmEntityProxy : MonoBehaviour
	{
		/// <summary>
		/// The AudioSource component will play/stop audio in Unity.
		/// </summary>
		public AudioSource AudioSource
		{
			get
			{
				return _audioSource;
			}
			set
			{
				_audioSource = value;
				_entity = new RhythmEntityUnity(_audioSource);
			}
		}

		/// <summary>
		/// The current time in seconds of the audio.
		/// </summary>
		public float Time => _entity.Time;

		/// <summary>
		/// The total time in seconds of the audio.
		/// </summary>
		public float TotalTime => _entity.TotalTime;

		/// <summary>
		/// True if the audio is playing.
		/// </summary>
		public bool IsPlaying => _entity.IsPlaying;

		[Header("References")]

		[SerializeField]
		private AudioSource _audioSource = null;

		private RhythmEntityUnity _entity = null;
		private RhythmEntityCommandUpdater<AudioSource> _entityUpdater = null;

		/// <summary>
		/// Plays the audio from the beginning.
		/// </summary>
		public void Play()
		{
			_entity.Play();
		}

		/// <summary>
		/// Plays the audio at a specific time.
		/// </summary>
		/// <param name="time">Time to play the audio at in seconds.</param>
		public void PlayAt(float time)
		{
			_entity.PlayAt(time);
		}

		/// <summary>
		/// Plays the audio at a specific time for a specific duration.
		/// </summary>
		/// <param name="time">Time to play the audio at in seconds.</param>
		/// <param name="duration">The duration to play the audio for in seconds.</param>
		public void PlayAt(float time, float duration)
		{
			_entity.PlayAt(time, duration);
		}

		/// <summary>
		/// Stops the audio.
		/// </summary>
		public void Stop()
		{
			_entity.Stop();
		}

		/// <summary>
		/// Loads an array of BeatCommand classes.
		/// These commands will automatically get executed when the audio is playing.
		/// </summary>
		/// <param name="beatCommands">An array of BeatCommand classes that need to be executed when the audio is playing.</param>
		public void LoadBeatCommands(BeatCommand[] beatCommands)
		{
			_entityUpdater = new RhythmEntityCommandUpdater<AudioSource>(_entity, beatCommands);
		}

		private void Start()
		{
			_entity = new RhythmEntityUnity(_audioSource);
		}

		private void Update()
		{
			if (_entityUpdater == null)
				return;

			if (!_entity.IsPlaying)
				return;

			_entityUpdater.Update();
		}
	}
}