using NUnit.Framework;
using UnityEngine;

namespace CM.Rhythm
{
	internal class RhythmTests
	{
		[Test]
		public void RhythmEntityProxy_CanPlayAudio()
		{
			// Arrange
			RhythmEntityProxy entityProxy = new GameObject().AddComponent<RhythmEntityProxy>();
			AudioClip audioClip = Resources.Load<AudioClip>("AudioExample");
			entityProxy.AudioSource = entityProxy.gameObject.AddComponent<AudioSource>();
			entityProxy.AudioSource.clip = audioClip;

			// Act
			entityProxy.Play();

			// Assert
			Assert.IsTrue(entityProxy.IsPlaying);
		}

		[Test]
		public void RhythmEntityProxy_CanPlayAudioAt()
		{
			// Arrange
			RhythmEntityProxy entityProxy = new GameObject().AddComponent<RhythmEntityProxy>();
			AudioClip audioClip = Resources.Load<AudioClip>("AudioExample");
			entityProxy.AudioSource = entityProxy.gameObject.AddComponent<AudioSource>();
			entityProxy.AudioSource.clip = audioClip;

			// Act
			entityProxy.PlayAt(5);

			// Assert
			Assert.IsTrue(entityProxy.IsPlaying && entityProxy.Time == 5);
		}

		[Test]
		public void RhythmEntityProxy_CanPlayAudioAtDuration()
		{
			// Arrange
			RhythmEntityProxy entityProxy = new GameObject().AddComponent<RhythmEntityProxy>();
			AudioClip audioClip = Resources.Load<AudioClip>("AudioExample");
			entityProxy.AudioSource = entityProxy.gameObject.AddComponent<AudioSource>();
			entityProxy.AudioSource.clip = audioClip;

			// Act
			entityProxy.PlayAt(5, 5);

			// Assert
			Assert.IsTrue(entityProxy.IsPlaying && entityProxy.Time == 5);
		}

		[Test]
		public void RhythmEntityProxy_CanPlayAndStopAudio()
		{
			// Arrange
			RhythmEntityProxy entityProxy = new GameObject().AddComponent<RhythmEntityProxy>();
			AudioClip audioClip = Resources.Load<AudioClip>("AudioExample");
			entityProxy.AudioSource = entityProxy.gameObject.AddComponent<AudioSource>();
			entityProxy.AudioSource.clip = audioClip;

			// Act
			entityProxy.Play();

			if (!entityProxy.IsPlaying)
				Assert.Fail("Can't play audio.");

			entityProxy.Stop();

			if (entityProxy.IsPlaying)
				Assert.Fail("Can't stop audio.");

			// Assert
			Assert.IsTrue(!entityProxy.IsPlaying);
		}
	}
}