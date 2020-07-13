using UnityEngine;

namespace CM.Rhythm
{
	public sealed class RhythmEntityProxy : MonoBehaviour
	{
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
		public float Time => _entity.Time;
		public float TotalTime => _entity.TotalTime;
		public bool IsPlaying => _entity.IsPlaying;

		[Header("References")]

		[SerializeField]
		private AudioSource _audioSource = null;

		private RhythmEntityUnity _entity = null;
		private RhythmEntityCommandUpdater<AudioSource> _entityUpdater = null;

		public void Play()
		{
			_entity.Play();
		}

		public void PlayAt(float time)
		{
			_entity.PlayAt(time);
		}

		public void PlayAt(float time, float duration)
		{
			_entity.PlayAt(time, duration);
		}

		public void Stop()
		{
			_entity.Stop();
		}

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
			if (_entity.IsPlaying)
				_entityUpdater.Update();
		}
	}
}