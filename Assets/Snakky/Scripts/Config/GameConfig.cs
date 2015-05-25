using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public static class GameConfig
	{

		public const int LEVEL_FIRST = 1;
		public const int LEVELS_NUMBER = 3;
		public const int LIVES_PRO_LEVEL = 3;
		public const int FIELD_OBJECTS_Z = 0;

		// fly label
		public static class FlyLabel
		{
			public const float SIZE = 1f;
			public const float FLY_SPEED = 0.2f;
			public const float LIVE_TIME = 25f;
		}

		public static class Sound
		{
			public const float DEFAULT_VOLUME = 0.5f;
			public const bool DEFAULT_VIBRATION = true;
			public const float VIBRATION_TIME = 200f;    // miliseconds
		}

		public static class ConfigFiles
		{
			public const string LEVELS_DATA_CONFIG = "3";

			public static string getLoclizationFile (LanguagesEnum lg)
			{
				switch (lg) {
				case LanguagesEnum.EN:
					return "en";
				case LanguagesEnum.RU:
					return "ru";
				case LanguagesEnum.UA:
					return "ua";
				case LanguagesEnum.DE:
					return "de";
				default:
					Debug.Log ("Get default localization file");
					return "en";
				}
			}
		}
	}
}
