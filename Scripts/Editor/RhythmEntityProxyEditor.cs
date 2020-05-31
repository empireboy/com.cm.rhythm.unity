using UnityEditor;
using UnityEngine;

namespace CM.Rhythm
{
	[CustomEditor(typeof(RhythmEntityProxy))]
	public class RhythmEntityProxyEditor : Editor
	{
		private float _playAtTime = 0.0f;
		private float _playAtDuration = 0.0f;

		public override void OnInspectorGUI()
		{
			RhythmEntityProxy rhythmEntityProxy = (RhythmEntityProxy)target;

			DrawDefaultInspector();

			if (rhythmEntityProxy.AudioSource)
				rhythmEntityProxy.AudioSource.playOnAwake = false;

			EditorGUILayout.Space();

			if (!Application.isPlaying)
			{
				EditorGUILayout.HelpBox("Debugging information will show here in PlayMode.", MessageType.Info);
				return;
			}

			EditorGUILayout.LabelField("Debugging", EditorStyles.boldLabel);

			// Properties

			_playAtTime = EditorGUILayout.FloatField("PlayAt time", _playAtTime);
			_playAtDuration = EditorGUILayout.FloatField("PlayAt duration", _playAtDuration);

			// Play Button

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(" ");

			if (GUILayout.Button("Play"))
				rhythmEntityProxy.Play();

			EditorGUILayout.EndHorizontal();

			// PlayAt(time) Button

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(" ");

			if (GUILayout.Button("PlayAt " + _playAtTime + "s"))
				rhythmEntityProxy.PlayAt(_playAtTime);

			EditorGUILayout.EndHorizontal();

			// PlayAt(time, duration) Button

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(" ");

			if (GUILayout.Button("PlayAt " + _playAtTime + "s" + " for " + _playAtDuration + "s"))
				rhythmEntityProxy.PlayAt(_playAtTime, _playAtDuration);

			EditorGUILayout.EndHorizontal();

			// Stop Button

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(" ");

			if (GUILayout.Button("Stop"))
				rhythmEntityProxy.Stop();

			EditorGUILayout.EndHorizontal();
		}
	}
}