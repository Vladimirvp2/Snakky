using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System;

namespace Snakyy
{
	public class SoundManager : ISoundManager
	{
		static SoundManager manager;
		float m_Volume = GameConfig.Sound.DEFAULT_VOLUME;
		bool m_Vibration = GameConfig.Sound.DEFAULT_VIBRATION;
		string m_TestSourse;
		Dictionary<string, AudioSource> m_AudioData = new Dictionary<string, AudioSource> ();
		
		public static SoundManager GetInstance ()
		{
			if (manager == null) {
				lock (typeof(SoundManager)) {
					if (manager == null)
						manager = new SoundManager ();
				}
			}
			
			return manager;
		}
		
		public SoundManager ()
		{
			init ();
		}

		void init ()
		{
			Debug.Log ("Load sound dates...");
			// load audiodata
			GameObject soundDataObject = GameObject.Find ("SoundManager");
			AudioSource[] arr = soundDataObject.GetComponentsInChildren<AudioSource> ();
			foreach (AudioSource audio in arr) {
				if (audio != null) {
					m_AudioData.Add (audio.gameObject.name, audio);
					Debug.Log ("<<<<<<<<<<<<< " + audio.gameObject.name);
					m_TestSourse = audio.gameObject.name;
				}
			}

			Debug.Log ("Sound dates loaded successfully");
		}

		public void play (SoundEnum sound)
		{
			// find the according audiosource and play
			m_AudioData [m_TestSourse].Play ();

		}

		public void vibrate ()
		{
			if (m_Vibration) {
				Vibration.Vibrate (GameConfig.Sound.VIBRATION_TIME);
			}
		}

		// from 0 to 1
		public float volume {
			get { 
				return m_Volume;
			}
			set {
				if (value > 1.0f)
					m_Volume = 1.0f;
				else if (value < 0f)
					m_Volume = 0.0f;

				m_Volume = value;
			}
		}

		public bool vibration {
			get {
				return m_Vibration;
			}
			set {
				m_Vibration = value;
			}
		}
	}
}
