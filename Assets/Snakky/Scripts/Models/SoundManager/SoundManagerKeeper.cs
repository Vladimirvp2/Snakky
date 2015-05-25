using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public class SoundManagerKeeper : MonoBehaviour
	{

		void Awake ()
		{
			DontDestroyOnLoad (transform.gameObject);
		}
	}

}
