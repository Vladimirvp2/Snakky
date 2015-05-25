using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public interface ISoundManager 
	{
		void play(SoundEnum sound);
		void vibrate();
		// from 0 to 1
		float volume{get; set;}
		bool vibration{get; set;}
	}
}
